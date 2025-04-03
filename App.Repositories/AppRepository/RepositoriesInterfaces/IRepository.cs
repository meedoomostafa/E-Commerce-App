namespace App.Repositories.AppRepository;

public interface IRepository<T> where T : class
{
    Task Add(T entity);
    void Delete(T entity);
    Task<T> GetById(int id);
    List<T> GetAllAsync();
    Task SaveChanges();
}