/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Driver.App.Commands;
using Driver.App.Queries;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RideCompanion.Controllers.Base;
using RideCompanion.ViewModels;
using Shared.Infrastructure.CacheService;
using Trip.App.Queries;
using Trip.Domain.Dto;

namespace RideCompanion.Controllers;

/// <summary>
/// Driver controller
/// </summary>
[Authorize]
public class DriverController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly CacheService _cache;

    public DriverController(IMediator mediator, IMapper mapper, CacheService cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetDriversQuery());

        var viewModel = new DriverViewModel
        {
            Drivers = _mapper.Map<List<DriverDto>>(data)
        };

        return View(viewModel);
    }

    /// <summary>
    /// Get driver by Id
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Driver entity </returns>
    public async Task<IActionResult> GetDriverById(Guid id) =>
        Json(await _mediator.Send(new GetDriverByIdQuery(id)));

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateDriver(DriverViewModel viewModel)
    {
        await _mediator.Send(new CreateDriverCommand(viewModel.DriverDto.FullName, viewModel.DriverDto.BirthDate));

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateDriver(DriverViewModel viewModel)
    {
        await _mediator.Send(new UpdateDriverCommand(viewModel.DriverDto.Id, viewModel.DriverDto));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        await _mediator.Send(new DeleteDriverCommand(id));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Driver details
    /// </summary>
    /// <param name="id"> Driver id </param>
    /// <returns> View </returns>
    public async Task<IActionResult> DriverDetail([FromRoute] Guid id)
    {
        var driverDto = _mapper.Map<DriverDto>(await _mediator.Send(new GetDriverByIdQuery(id)));
        var carsListDto = _mapper.Map<List<CarDto>>(await _mediator.Send(new GetCarsByDriverIdQuery(id)));
        var tripsListDto = _mapper.Map<List<TripDto>>(await _mediator.Send(new GetTripsByDriverIdQuery(id)));
        var carModel = await _cache.GetCarBrandsFromCache();

        ViewBag.Brand = new SelectList(carModel, "Brand", "Brand");

        var viewModel = new DriverViewModel
        {
            DriverDto = driverDto,
            DriverId = driverDto.Id,
            Cars = carsListDto,
            Trips = tripsListDto
        };

        return View(viewModel);
    }

    /// <summary>
    /// Get car by Id
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Car entity </returns>
    public async Task<IActionResult> GetCarById(Guid id)
    {
        var data = await _mediator.Send(new GetCarByIdQuery(id));
        return Json(data);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateCar(DriverViewModel viewModel)
    {
        await _mediator.Send(new CreateCarCommand(viewModel.DriverDto.Id, viewModel.CarDto));
        return RedirectToAction("DriverDetail", new { id = viewModel.CarDto.DriverId });
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateCar(DriverViewModel viewModel)
    {
        await _mediator.Send(new UpdateCarCommand(viewModel.CarDto));

        return RedirectToAction("DriverDetail", new { id = viewModel.CarDto.DriverId });
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        var carEntity = await _mediator.Send(new GetCarByIdQuery(id));

        if (carEntity is not null)
        {
            await _mediator.Send(new DeleteCarCommand(id));
        }

        return RedirectToAction("DriverDetail", new { id = carEntity?.DriverId });
    }
}