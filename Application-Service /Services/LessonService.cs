using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DTOs;
using Service.Extensions;
using Service.Filters;
using Service.Interfaces;
using Service.Services;

namespace Service;

public class LessonService : BaseService<LessonEntity>, ILessonService
{
    public LessonService(AppDbContext context, ILogger logger ) : base(context, logger) {}

    public LessonService(AppDbContext context) : base(context)
    {
       
    }

    public async Task<IEnumerable<LessonEntity>> GetAllAsync(QueryParametersDto dto, LessonFilter filter, PageResult pagination)
    {
        return await Context.Lessons
            .AsNoTracking()
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination)
            .ToListAsync();
    }
}