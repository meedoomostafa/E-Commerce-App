using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Repositories.AppRepository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(Product entity)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == entity.Id);
        if (product != null)
        {
            product.Price = entity.Price;
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.ImageUrl = entity.ImageUrl;
        }
    }
}