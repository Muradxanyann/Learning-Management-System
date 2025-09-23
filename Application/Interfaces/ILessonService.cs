using Application.DTOs;
using Application.Filters;
using Domain;

namespace Application.Interfaces;

public interface ILessonService : IBaseService<LessonEntity>
{
    public Task<IEnumerable<LessonEntity>> GetAllAsync(QueryParametersDto dto, LessonFilter filter, PageResult pagination);
} 