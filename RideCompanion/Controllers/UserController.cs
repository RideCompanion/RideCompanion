using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;

namespace RideCompanion.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    
    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }

    
}