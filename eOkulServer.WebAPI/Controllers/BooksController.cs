using eOkulServer.Application.Features.Books.AddNewBokImages;
using eOkulServer.Application.Features.Books.ChangeBookCoverImage;
using eOkulServer.Application.Features.Books.CreateBook;
using eOkulServer.Application.Features.Books.GetAllBooks;
using eOkulServer.Application.Features.Books.RemoveBookImage;
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

    [HttpPost]
    public async Task<IActionResult> ChangeCoverImage(ChangeBookCoverImageCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewImages([FromForm] AddNewBokImagesCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveImage(RemoveBookImageCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

}
