using eOkulServer.Application.Features.Categories.CreateCategory;
using eOkulServer.Application.Features.Categories.DeleteByIdCategory;
using eOkulServer.Application.Features.Categories.GetAllCategory;
using eOkulServer.Application.Features.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOkulServer.WebAPI.Controllers;
public sealed class Categories : ApiBase
{
    public Categories(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllCategoriesQuery request = new();
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
