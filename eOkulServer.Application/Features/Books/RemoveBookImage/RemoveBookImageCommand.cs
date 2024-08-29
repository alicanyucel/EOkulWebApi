using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.Books.RemoveBookImage;
public sealed record RemoveBookImageCommand(
    Guid BookId,
    string ImageUrl) : IRequest<Result<string>>;