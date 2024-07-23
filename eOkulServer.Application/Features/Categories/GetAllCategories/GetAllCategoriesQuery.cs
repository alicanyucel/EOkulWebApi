using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using MediatR;

namespace eOkulServer.Application.Features.Categories.GetAllCategory;
public sealed record GetAllCategoriesQuery() : IRequest<Result<List<Category>>>;