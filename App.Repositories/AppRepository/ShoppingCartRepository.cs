using System.Linq.Expressions;
using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private readonly AppDbContext _context;

    public ShoppingCartRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(ShoppingCart entity)
    {
        var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(sc => sc.Id == entity.Id);
        if (shoppingCart != null)
        {
            shoppingCart.Items = entity.Items;
        }
    }


}