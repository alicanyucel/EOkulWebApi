using eOkulServer.Domain.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eOkulServer.Application.Features.Books.AddNewBokImages;
public sealed record AddNewBokImagesCommand(
    Guid BookId,
    List<IFormFile> Files) : IRequest<Result<List<string>>>;