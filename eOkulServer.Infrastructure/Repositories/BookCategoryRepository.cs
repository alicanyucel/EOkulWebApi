using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;

namespace eOkulServer.Infrastructure.Repositories;

internal sealed class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
