namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    IShoppingCartRepository ShoppingCart { get; }
    IWishlistRepository Wishlist { get; }
    ICartItemRepository CartItem { get; }
    Task SaveChanges();
}