using eOkulServer.Domain.Abstracts;
using System.Linq.Expressions;

namespace eOkulServer.Domain.Repositories;
public interface IRepository<T>
    where T : Entity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task CreateRangeAsync(List<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}
