using System.ComponentModel.Design.Serialization;
using App.Models.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.AppRepository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(Order entity)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (order != null)
        {
            order.Carrier = entity.Carrier;
            order.City = entity.City;
            order.Name = entity.Name;
            order.OrderDate = entity.OrderDate;
            order.OrderTotal = entity.OrderTotal;
        }
    }
}