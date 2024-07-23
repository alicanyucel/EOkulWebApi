using eOkulServer.Domain.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eOkulServer.Application.Features.Books.CreateBook;
public sealed record CreateBookCommand(
    string Title,
    string Author,
    string Summary,
    string ISBN,
    IFormFile CoverImage,
    List<IFormFile> Images,
    List<Guid> CategoryIds
    ) : IRequest<Result<string>>;