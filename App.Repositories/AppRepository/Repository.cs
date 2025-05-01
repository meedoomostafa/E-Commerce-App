using System.Linq.Expressions;
using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace App.Repositories.AppRepository;

public class Repository<T> : IRepository<T>  where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(T entity)
    {
        await _context.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public async Task<T?> GetById(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var  query = _context.Set<T>().AsQueryable();
        if (include != null)
        {
            query = include(query);
        }
        return query.ToList();
    }

    public async Task<T?> GetByIdAsync(int id, Func<IQueryable<T>
        , IIncludableQueryable<T, object>> include = null , bool isTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (!isTracking)
        {
            query = query.AsNoTracking();           
        }
        if (include != null)
        {
            query = include(query);
        }
        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>
        , IIncludableQueryable<T, object>>? include = null , bool isTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (!isTracking)
        {
            query = query.AsNoTracking();           
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }
        
        if (include != null)
        {
            query = include(query);
        }
        return await query.ToListAsync();
    }

    public Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter
        , Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null , bool isTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (!isTracking)
        {
            query = query.AsNoTracking();            
        }
        if (include != null)
        {
            query = include(query);
        }
        return query.FirstOrDefaultAsync(filter);
    }
}