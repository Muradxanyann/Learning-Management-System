using Domain;
using Service.DTOs;
using Service.Filters;

namespace Service.Interfaces;

public interface ILessonService : IBaseService<LessonEntity>
{
    public Task<IEnumerable<LessonEntity>> GetAllAsync(QueryParametersDto dto, LessonFilter filter, PageResult pagination);
} 