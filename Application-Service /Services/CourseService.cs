using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DTOs;
using Service.Extensions;
using Service.Filters;
using Service.Interfaces;

namespace Service.Services;

public class CourseService : BaseService<CourseEntity>, ICourseService
{
    public CourseService(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public CourseService(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CourseEntity>> GetAllAsync(QueryParametersDto dto,  CourseFilter filter,  PageResult pagination)
    {
        return await Context.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination)
            .ToListAsync();
    }
    public new async Task<CourseEntity?> GetByIdAsync(Guid id) 
    {
        return await Context.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(c => c.CourseId == id);
    }
    
}
    