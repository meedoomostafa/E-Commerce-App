using App.Models.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;

namespace App.Repositories.AppRepository;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    private readonly AppDbContext _context;
    public OrderItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(OrderItem entity)
    {

    }
}