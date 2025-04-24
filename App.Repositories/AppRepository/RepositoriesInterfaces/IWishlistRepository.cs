using App.Models.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IWishlistRepository : IRepository<Wishlist>
{
    Task Update(Wishlist entity);
}