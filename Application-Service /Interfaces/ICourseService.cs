using Domain;
using Service.DTOs;


namespace Service.Interfaces;

public interface ICourseService : IBaseService<CourseEntity>
{
    public new Task<IEnumerable<CourseEntity>> GetAllAsync(QueryParametersDto dto);
    public new Task<CourseEntity?> GetByIdAsync(Guid id);
}