using Application.DTOs;
using Application.Extensions;
using Application.Filters;
using Application.Interfaces;
using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class CourseService : BaseService<CourseEntity>, ICourseService
{
    public CourseService(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public CourseService(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CourseEntity>> GetAllAsync(
        QueryParametersDto dto,
        CourseFilter filter,
        PageResult pagination,
        CancellationToken ct = default)
    {
        return await Context.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination)
            .ToListAsync(ct);
    }
    public new async Task<CourseEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) 
    {
        return await Context.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(c => c.CourseId == id, ct);
    }
    
}
    