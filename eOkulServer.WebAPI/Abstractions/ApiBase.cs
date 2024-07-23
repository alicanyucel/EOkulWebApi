using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOkulServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiBase : ControllerBase
{
    public readonly IMediator mediator;

    protected ApiBase(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
