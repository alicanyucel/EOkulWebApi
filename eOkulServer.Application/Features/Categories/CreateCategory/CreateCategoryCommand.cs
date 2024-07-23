using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(string Name) : IRequest<Result<string>>;
