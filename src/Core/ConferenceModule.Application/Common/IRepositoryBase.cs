using System.Linq.Expressions;

namespace ConferenceModule.Application.Common;

public interface IRepositoryBase<T> where T : class {
    IQueryable<T> FindAll();
    Task<T?> GetByIdAsync<TU>(TU id, CancellationToken cancellationToken);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Expression<Func<T,bool>> expression, CancellationToken cancellationToken);
}