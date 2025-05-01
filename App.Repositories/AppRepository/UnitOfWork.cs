using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;

namespace App.Repositories.AppRepository;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _context;
    public IProductRepository Product { get; private set;}
    public ICategoryRepository Category { get; private set;}
    public IWishlistRepository Wishlist { get; private set;}
    public IShoppingCartRepository ShoppingCart { get; private set;}
    public ICartItemRepository CartItem { get; private set;}
    
    public IReviewRepository Review { get; private set;}
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Product = new ProductRepository(_context);
        Category = new CategoryRepository(_context);
        Wishlist = new WishlistRepository(_context);
        CartItem = new CartItemRepository(_context);       
        ShoppingCart = new ShoppingCartRepository(_context);
        Review = new ReviewRepository(_context);
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}