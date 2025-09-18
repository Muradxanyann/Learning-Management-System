using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DTOs;
using Service.Extensions;
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

    public new async Task<IEnumerable<CourseEntity>> GetAllAsync(QueryParametersDto dto)
    {
        return await Context.Courses
            .Include(c => c.Lessons)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ToListAsync();
    }
    public new async Task<CourseEntity?> GetByIdAsync(Guid id) 
    {
        return await Context.Courses
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(c => c.CourseId == id);
    }
    
}
    