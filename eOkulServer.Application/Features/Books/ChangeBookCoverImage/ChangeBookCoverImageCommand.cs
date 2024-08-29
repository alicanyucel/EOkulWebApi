using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.Books.ChangeBookCoverImage;
public sealed record ChangeBookCoverImageCommand(
    Guid BookId,
    string ImageUrl) : IRequest<Result<string>>;
