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
using RideCompanion.Controllers.Base;
using RideCompanion.ViewModels;
using Trip.App.Queries;
using Trip.Domain.Dto;

namespace RideCompanion.Controllers;

/// <summary>
/// Driver controller
/// </summary>
[Authorize]
public class DriverController : BaseController
{
    public DriverController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var data = await Mediator.Send(new GetDriversQuery());

        var viewModel = new DriverViewModel
        {
            Drivers = Mapper.Map<List<DriverDto>>(data)
        };

        return View(viewModel);
    }

    /// <summary>
    /// Get driver by Id
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Driver entity </returns>
    public async Task<IActionResult> GetDriverById(Guid id)
    {
        var data = await Mediator.Send(new GetDriverByIdQuery
        {
            Id = id
        });

        ViewData["driver"] = data;

        return Json(data);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateDriver(DriverViewModel viewModel)
    {
        await Mediator.Send(new CreateDriverCommand(viewModel.DriverDto!.FullName, viewModel.DriverDto.BirthDate));

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateDriver(DriverViewModel viewModel)
    {
        await Mediator.Send(new UpdateDriverCommand
        {
            DriverId = viewModel.DriverDto!.Id,
            DriverDto = viewModel.DriverDto
        });

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        await Mediator.Send(new DeleteDriverCommand
        {
            DriverId = id
        });

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Driver details
    /// </summary>
    /// <param name="driverId"> Driver id </param>
    /// <returns> View </returns>
    public async Task<IActionResult> DriverDetail(Guid driverId)
    {
        var driverData = await Mediator.Send(new GetDriverByIdQuery
        {
            Id = driverId
        });

        var carList = await Mediator.Send(new GetCarsByDriverIdQuery
        {
            DriverId = driverId
        });
            
        var tripList = await Mediator.Send(new GetTripsByDriverIdQuery
        {
            DriverId = driverId
        });

        var viewModel = new DriverViewModel
        {
            DriverDto = Mapper.Map<DriverDto>(driverData),
            Cars = Mapper.Map<List<CarDto>>(carList),
            Trips = Mapper.Map<List<TripDto>>(tripList)
        };

        return View(viewModel);
    }

    // -------------------------------------------
    // Car
    // -------------------------------------------

    /// <summary>
    /// Cars
    /// </summary>
    /// <param name="driverId"> Driver id </param>
    /// <returns> View </returns>
    public async Task<IActionResult> Cars(Guid driverId)
    {
        var data = await Mediator.Send(new GetCarsByDriverIdQuery
        {
            DriverId = driverId
        });

        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }

        return View();
    }


    /// <summary>
    /// Get car by Id
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Car entity </returns>
    public async Task<IActionResult> GetCarById(Guid id)
    {
        var data = await Mediator.Send(new GetCarByIdQuery
        {
            Id = id
        });

        ViewData["car"] = data;

        return Json(data);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateCar(DriverViewModel viewModel)
    {
        await Mediator.Send(new CreateCarCommand
        {
            DriverId = viewModel.DriverDto!.Id,
            Number = viewModel.CarDto!.Number,
            Color = viewModel.CarDto.Color,
            Model = viewModel.CarDto.Model
        });

        return RedirectToAction("DriverDetail", viewModel.DriverDto.Id);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateCar(DriverViewModel viewModel)
    {
        await Mediator.Send(new UpdateCarCommand(viewModel.CarDto!));

        return RedirectToAction("DriverDetail", viewModel.CarDto!.DriverId);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        await Mediator.Send(new DeleteCarCommand
        {
            CarId = id
        });

        return RedirectToAction("DriverDetail", id);
    }
}