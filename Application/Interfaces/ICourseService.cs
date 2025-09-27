using Application.DTOs;
using Application.Filters;
using Domain;

namespace Application.Interfaces;

public interface ICourseService : IBaseService<CourseEntity>
{
    public Task<IEnumerable<CourseEntity>> GetAllAsync(
        QueryParametersDto dto, 
        CourseFilter filter, 
        PageResult pagination,  
        CancellationToken cancellationToken = default);
    public new Task<CourseEntity?> GetByIdAsync(Guid id,  CancellationToken cancellationToken = default);
}