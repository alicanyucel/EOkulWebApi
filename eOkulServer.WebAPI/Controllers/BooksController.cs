using eOkulServer.Application.Features.Books.CreateBook;
using eOkulServer.Application.Features.Books.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eOkulServer.WebAPI.Controllers;
public class BooksController : ApiBase
{
    public BooksController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateBookCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid? categoryId, CancellationToken cancellationToken)
    {
        GetAllBooksQuery request = new(categoryId);
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
