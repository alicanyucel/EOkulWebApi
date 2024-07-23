using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;

namespace eOkulServer.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
