using App.Models.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task Update(Order entity);
}