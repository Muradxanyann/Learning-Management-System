using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly AppDbContext Context;
    private readonly ILogger _logger = null!;
    

    protected BaseService(AppDbContext context,  ILogger logger)
    {
        Context = context;
        _logger = logger;
    }


    protected BaseService(AppDbContext context)
    {
        Context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync(QueryParametersDto dto,  CancellationToken ct = default)
    {
        return await Context.Set<T>()
            .AsNoTracking()
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ToListAsync(ct);
    }

    public async Task<T?> GetByIdAsync(Guid id,  CancellationToken ct = default)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public Task<T> CreateAsync(T entity,  CancellationToken ct = default)
    {
         Context.Set<T>().Add(entity);
         return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(Guid id,   CancellationToken ct = default)
    {
        var entity = await Context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            _logger.LogError("Entity with id {Guid} was not found", id);
            return false;
        }
        Context.Set<T>().Remove(entity);
        return true;
    }
}

