namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    Task SaveChanges();
}