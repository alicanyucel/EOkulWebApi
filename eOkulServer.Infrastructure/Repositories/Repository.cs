using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Repositories;
using eOkulServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eOkulServer.Infrastructure.Repositories;
internal class Repository<T>(
    ApplicationDbContext context) : IRepository<T>
    where T : Entity
{
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().AnyAsync(predicate, cancellationToken);
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
    }

    public void Delete(T entity)
    {
        context.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync(id, cancellationToken);
    }

    public void Update(T entity)
    {
        context.Update(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate);
    }
}
