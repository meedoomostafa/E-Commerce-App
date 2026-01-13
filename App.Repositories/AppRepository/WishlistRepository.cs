using App.Models.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository;

public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
{
    private readonly AppDbContext _context;

    public WishlistRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(Wishlist entity)
    {
        var wishlist = await _context.Wishlists.FirstOrDefaultAsync(w => w.Id == entity.Id);
        if (wishlist != null)
        {
            wishlist.Items = entity.Items;
        }
    }
}