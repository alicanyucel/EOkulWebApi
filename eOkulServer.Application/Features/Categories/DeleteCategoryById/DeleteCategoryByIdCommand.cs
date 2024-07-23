using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.Categories.DeleteByIdCategory;
public sealed record DeleteCategoryByIdCommand(Guid Id) : IRequest<Result<string>>;
