using Domain.Exceptions;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly AppDbContext Context;
    private readonly ILogger _logger = null!; 

    public BaseService(AppDbContext context,  ILogger logger)
    {
        Context = context;
        _logger = logger;
    }

    
    public BaseService(AppDbContext context)
    {
        Context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public Task<T> CreateAsync(T entity)
    {
         Context.Set<T>().Add(entity);
         return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            _logger.LogError($"Entity with id {id} was not found");
            return false;
        }
        Context.Set<T>().Remove(entity);
        return true;
    }
}

