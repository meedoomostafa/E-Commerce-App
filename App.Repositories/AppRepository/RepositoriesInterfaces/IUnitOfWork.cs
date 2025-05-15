namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    IShoppingCartRepository ShoppingCart { get; }
    IWishlistRepository Wishlist { get; }
    ICartItemRepository CartItem { get; }
    IReviewRepository Review { get; }
    IOrderRepository Order { get; }
    IOrderItemRepository OrderItem { get; }
    Task SaveChanges();
}