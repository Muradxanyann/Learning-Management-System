using Domain;
using Service.DTOs;
using Service.Filters;


namespace Service.Interfaces;

public interface ICourseService : IBaseService<CourseEntity>
{
    public Task<IEnumerable<CourseEntity>> GetAllAsync(QueryParametersDto dto, CourseFilter filter, PageResult pagination);
    public new Task<CourseEntity?> GetByIdAsync(Guid id);
}