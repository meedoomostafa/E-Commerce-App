using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using App.Repositories.Migrations;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.AppRepository;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    private readonly AppDbContext _context;
    public CartItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(CartItem entity)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == entity.Id);
        if (cartItem != null)
        {
            cartItem.Quantity = entity.Quantity;
        }
    }
}