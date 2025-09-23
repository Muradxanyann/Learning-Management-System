using Application.DTOs;

namespace Application.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(QueryParametersDto dto);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}