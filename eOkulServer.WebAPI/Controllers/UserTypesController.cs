using eOkulServer.Application.Features.UserTypes.CreateUserType;
using eOkulServer.Application.Features.UserTypes.DeleteUserTypeById;
using eOkulServer.Application.Features.UserTypes.GetAllUserTypes;
using eOkulServer.Application.Features.UserTypes.UpdateUserType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOkulServer.WebAPI.Controllers;
public class UserTypesController : ApiBase
{
    public UserTypesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllUserTypesQuery request = new();
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteUserTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
