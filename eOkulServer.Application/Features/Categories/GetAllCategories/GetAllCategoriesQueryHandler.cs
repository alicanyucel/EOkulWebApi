using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eOkulServer.Application.Features.Categories.GetAllCategory;

internal sealed class GetAllCategoriesQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return
            await categoryRepository
            .GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }
}
