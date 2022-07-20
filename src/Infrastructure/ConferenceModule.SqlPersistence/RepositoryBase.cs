using System.Linq.Expressions;
using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class {
    private readonly MediaContext _mediaContext;

    public RepositoryBase(MediaContext mediaContext) {
        _mediaContext = mediaContext;
    }


    public IQueryable<T> FindAll() {
        return _mediaContext.Set<T>().AsNoTracking().TagWith(MethodCalled());
    }

    public async Task<T?> GetByIdAsync<TU>(TU id, CancellationToken cancellationToken) {
        return await _mediaContext.Set<T>().FindAsync(new object[] {id!}, cancellationToken);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) {
        return _mediaContext.Set<T>().Where(expression).AsNoTracking().TagWith(MethodCalled());
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken) {
        _mediaContext.Set<T>().Add(entity);
        RaiseEvent(entity);
        await _mediaContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken) {
        _mediaContext.Set<T>().Update(entity);
        RaiseEvent(entity);
        await _mediaContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public Task<int> DeleteAsync(T entity, CancellationToken cancellationToken) {
        _mediaContext.Set<T>().Remove(entity);
        RaiseEvent(entity);
        return _mediaContext.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) {
        return _mediaContext.Set<T>().AsNoTracking().TagWith(MethodCalled()).AnyAsync(expression, cancellationToken);
    }

    private static string MethodCalled(int indexFrame = 5) {
        var stackTrace = new System.Diagnostics.StackTrace();
        var index = stackTrace.GetFrames().Length < indexFrame - 1 ? 1 : indexFrame;
        var method = stackTrace.GetFrame(index)!.GetMethod()!;
        return $"{method.DeclaringType!.Name}_{method.Name}";
    }


    private static void RaiseEvent(object entity) {
        if (entity is ConferenceDetail conferenceDetail) {
            conferenceDetail.AddEvent(new ConferenceDetailEvent(conferenceDetail));
        }
    }
}