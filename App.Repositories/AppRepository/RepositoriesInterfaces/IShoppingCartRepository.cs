using App.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    Task Update(ShoppingCart entity);   
}