using App.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IProductRepository  : IRepository<Product>
{
    Task Update(Product entity);
}