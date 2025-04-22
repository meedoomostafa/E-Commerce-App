using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IRepository<T> where T : class
{
    Task Add(T entity);
    void Delete(T entity);
    Task<T?> GetById(int id);
    IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include  = null);
    Task<T?> GetByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
}