namespace Service.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}