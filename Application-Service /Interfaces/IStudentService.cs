using Domain;
using Service.DTOs;
using Service.Filters;


namespace Service.Interfaces;

public interface IStudentService : IBaseService<StudentEntity>
{
    
    public Task<IEnumerable<StudentEntity>> GetAllAsync(QueryParametersDto dto, StudentFilter filter, PageResult pagination);
    public Task<StudentEntity?> GetByIdWithCoursesAsync(Guid id);
}