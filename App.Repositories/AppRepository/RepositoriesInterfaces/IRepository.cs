using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IRepository<T> where T : class
{
    Task Add(T entity);
    void Delete(T entity);
    Task<T?> GetById(int id);
    IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<T?> GetByIdAsync(int id, Func<IQueryable<T>
        , IIncludableQueryable<T, object>> include = null, bool isTracking = true);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>
        , IIncludableQueryable<T, object>>? include = null, bool isTracking = true);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool isTracking = true);
}