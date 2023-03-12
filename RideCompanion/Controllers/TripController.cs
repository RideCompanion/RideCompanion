/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Companion.App.Queries;
using Companion.Domain.Dto;
using Driver.App.Queries;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RideCompanion.Controllers.Base;
using RideCompanion.ViewModels;
using Trip.App.Commands;
using Trip.App.Queries;
using Trip.App.TripBuilder;
using Trip.Domain.Dto;
using User.Domain.Entities;

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
    private readonly UserManager<UserEntity> _userManager;

    public TripController(IMediator mediator, IMapper mapper, UserManager<UserEntity> userManager, ITripDirector tripDirector)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tripDirector = tripDirector;
        _userManager = userManager;
    }
    
    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        
        if(userId == null)
            return RedirectToAction("Index", "Home");
        
        var tripsList = await _mediator.Send(new GetTripsQuery());
        var companions = await _mediator.Send(new GetCompanionsByUserIdQuery(Guid.Parse(userId)));
        var drivers = await _mediator.Send(new GetDriverByUserIdQuery(Guid.Parse(userId)));
        var cars = await _mediator.Send(new GetCarsByUserIdQuery(Guid.Parse(userId)));

        if(!companions.Any())
            return RedirectToAction("Index", "Companion");
        
        if(!drivers.Any())
            return RedirectToAction("Index", "Driver");
        
        ViewBag.Companions = new SelectList(companions, "Id", "FullName");
        ViewBag.Drivers = new SelectList(drivers, "Id", "FullName");
        ViewBag.Cars = new SelectList(cars, "Id", "Number");
        
        var viewModel = new TripViewModel
        {
            Trips = _mapper.Map<List<TripDto>>(tripsList),
            Companions = _mapper.Map<List<CompanionDto>>(companions),
            Drivers = _mapper.Map<List<DriverDto>>(drivers),
            Cars = _mapper.Map<List<CarDto>>(cars)
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