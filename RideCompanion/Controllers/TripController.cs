/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;
using RideCompanion.ViewModels;
using Trip.App.Commands;
using Trip.App.Queries;
using Trip.App.TripBuilder;
using Trip.Domain.Dto;

namespace RideCompanion.Controllers;

/// <summary>
/// Trip controller
/// </summary>
[Authorize]
public class TripController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITripDirector _tripDirector;
    
    public TripController(IMediator mediator, IMapper mapper, ITripDirector tripDirector)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tripDirector = tripDirector;
    }
    
    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var tripList = await _mediator.Send(new GetTripsQuery());
        
        var viewModel = new TripViewModel
        {
            Trips = _mapper.Map<List<TripDto>>(tripList)
        };
            
        return View(viewModel);
    }

    /// <summary>
    /// Get Trip By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> GetTripById(Guid id)
    {
        var data = await _mediator.Send(new GetTripByIdQuery(id));
        return Json(data);
    }

    /// <summary>
    /// Create Trip
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> CreateTrip(TripViewModel viewModel)
    {
        await _mediator.Send(new CreateTripCommand(_tripDirector.BuildTrip(viewModel.TripDto!)));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update Trip
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> UpdateTrip(TripViewModel viewModel)
    {
        await _mediator.Send(new UpdateTripCommand(viewModel.TripDto!));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete Trip
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteTrip(Guid id)
    {
        await _mediator.Send(new DeleteTripCommand(id));
        return RedirectToAction("Index");
    }
}