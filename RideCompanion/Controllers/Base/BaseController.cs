using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers.Base;

/// <summary>
/// Base controller
/// </summary>
public class BaseController : Controller
{
    protected readonly IMediator Mediator;
    protected readonly IMapper Mapper;

    public BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }
}