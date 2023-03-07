/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Companion.App.Commands;
using Companion.App.Queries;
using Companion.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;
using RideCompanion.ViewModels;

namespace RideCompanion.Controllers;

/// <summary>
/// Companion controller
/// </summary>
[Authorize]
public class CompanionController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public CompanionController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetCompanionsQuery());
        var viewModel = new CompanionViewModel
        {
            Companions = _mapper.Map<List<CompanionDto>>(data)
        };
        return View(viewModel);
    }
    
    /// <summary>
    /// Get Companion By Id
    /// </summary>
    /// <param name="id"> Id </param>
    /// <returns> Companions list </returns>
    public async Task<IActionResult> GetCompanionById(Guid id)
    {
        var data = await _mediator.Send(new GetCompanionByIdQuery(id));
        return Json(data);
    }

    /// <summary>
    /// Create Companion
    /// </summary>
    /// <param name="viewModel"> View model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateCompanion(CompanionViewModel viewModel)
    {
        await _mediator.Send(new CreateCompanionCommand(viewModel.CompanionDto!));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update Companion
    /// </summary>
    /// <param name="viewModel"> View model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateCompanion(CompanionViewModel viewModel)
    {
        await _mediator.Send(new UpdateCompanionCommand(viewModel.CompanionDto!));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete Companion
    /// </summary>
    /// <param name="id"> Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteCompanion(Guid id)
    {
        await _mediator.Send(new DeleteCompanionCommand(id));
        return RedirectToAction("Index");
    }
}