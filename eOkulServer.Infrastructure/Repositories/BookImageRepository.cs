using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;

namespace eOkulServer.Infrastructure.Repositories;

internal sealed class BookImageRepository : Repository<BookImage>, IBookImageRepository
{
    public BookImageRepository(ApplicationDbContext context) : base(context)
    {
    }
}