using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;

namespace App.Repositories.AppRepository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _dbContext;
    public CategoryRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task Update(Category entity)
    {
        var category = await _dbContext.Categories.FindAsync(entity.Id);
        if (category != null)
        {
            category.Description = entity.Description;
            category.Name = entity.Name;
        }
    }
}