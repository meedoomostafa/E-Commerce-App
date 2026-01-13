using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.AppRepository;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    private readonly AppDbContext _context;
    public ReviewRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Update(Review entity)
    {
        var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == entity.Id);
        if (review != null)
        {
            review.Comment = entity.Comment;
            review.Rating = entity.Rating;
            review.ProductId = entity.ProductId;
            review.UserId = entity.UserId;
        }
    }
}