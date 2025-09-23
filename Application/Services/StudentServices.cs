using Application.DTOs;
using Application.Extensions;
using Application.Filters;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class StudentService : BaseService<StudentEntity>, IStudentService
{
   

    public StudentService(AppDbContext context, ILogger logger, IMapper mapper) : base(context, logger)
    {
    }

    public StudentService(AppDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<StudentEntity>> GetAllAsync(QueryParametersDto dto, StudentFilter filter, PageResult pagination)
    {
        return await Context.Students
            .AsNoTracking()
            .Include(s => s.StudentCourses)
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task<StudentEntity?> GetByIdWithCoursesAsync(Guid id)
    {
        return await Context.Students
            .AsNoTracking()
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(s => s.StudentId == id);
    }

    
}