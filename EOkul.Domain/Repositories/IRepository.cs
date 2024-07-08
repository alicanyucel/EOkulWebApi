

using EOkul.Domain.Abstracts;
using System.Linq.Expressions;

namespace EOkul.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken=default);
}