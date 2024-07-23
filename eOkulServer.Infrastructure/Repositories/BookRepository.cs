using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;

namespace eOkulServer.Infrastructure.Repositories;
internal sealed class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}