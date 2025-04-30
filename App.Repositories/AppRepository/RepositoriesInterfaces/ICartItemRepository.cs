using App.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface ICartItemRepository : IRepository<CartItem>
{
    Task Update(CartItem entity);
}