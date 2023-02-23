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
    public TripController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    
    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var data = await Mediator.Send(new GetTripsQuery());
        
        var viewModel = new TripViewModel
        {
            Trips = Mapper.Map<List<TripDto>>(data)
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
        var data = await Mediator.Send(new GetTripByIdQuery(id));
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
        var director = new TripDirector(new TripBuilder());
        var trip = director.BuildFullTrip(viewModel.TripDto!);
        await Mediator.Send(new CreateTripCommand(trip));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update Trip
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> UpdateTrip(TripViewModel viewModel)
    {
        await Mediator.Send(new UpdateTripCommand(viewModel.TripDto!));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete Trip
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteTrip(Guid id)
    {
        await Mediator.Send(new DeleteTripCommand(id));
        return RedirectToAction("Index");
    }
}