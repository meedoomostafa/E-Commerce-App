using App.Models;

namespace App.Repositories.AppRepository.RepositoriesInterfaces;

public interface IReviewRepository : IRepository<Review>
{
    Task Update(Review entity);
}