using System.Linq.Expressions;
using App.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    Task Update(ShoppingCart entity);
}