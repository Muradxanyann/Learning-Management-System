using Domain;
using Service.DTOs;


namespace Service.Interfaces;

public interface IStudentService : IBaseService<StudentEntity>
{
    public new Task<IEnumerable<StudentEntity>> GetAllAsync(QueryParametersDto dto);
    public Task<StudentEntity?> GetByIdWithCoursesAsync(Guid id);
}