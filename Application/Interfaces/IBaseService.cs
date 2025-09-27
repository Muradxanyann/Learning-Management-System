using Application.DTOs;

namespace Application.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(QueryParametersDto dto,  CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id,  CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity,  CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id,  CancellationToken cancellationToken = default);
}