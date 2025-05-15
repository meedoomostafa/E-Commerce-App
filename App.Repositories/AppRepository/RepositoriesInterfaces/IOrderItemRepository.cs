using App.Models.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task Update(OrderItem entity);
}