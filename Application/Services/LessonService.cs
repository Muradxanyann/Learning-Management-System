using Application.DTOs;
using Application.Extensions;
using Application.Filters;
using Application.Interfaces;
using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class LessonService : BaseService<LessonEntity>, ILessonService
{
    public LessonService(AppDbContext context, ILogger logger ) : base(context, logger) {}

    public LessonService(AppDbContext context) : base(context)
    {
       
    }

    public async Task<IEnumerable<LessonEntity>> GetAllAsync(
        QueryParametersDto dto,
        LessonFilter filter,
        PageResult pagination,
        CancellationToken ct = default)
    {
        return await Context.Lessons
            .AsNoTracking()
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination)
            .ToListAsync(ct);
    }
}