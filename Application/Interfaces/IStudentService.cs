using Application.DTOs;
using Application.Filters;
using Domain;

namespace Application.Interfaces;

public interface IStudentService : IBaseService<StudentEntity>
{
    
    public Task<IEnumerable<StudentEntity>> GetAllAsync(QueryParametersDto dto, StudentFilter filter, PageResult pagination);
    public Task<StudentEntity?> GetByIdWithCoursesAsync(Guid id);
}