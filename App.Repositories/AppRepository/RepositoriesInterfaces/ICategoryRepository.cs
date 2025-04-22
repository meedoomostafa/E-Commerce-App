using App.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task Update(Category entity);
}