using AutoMapper;
using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DTOs;
using Service.Extensions;
using Service.Interfaces;

namespace Service.Services;

public class StudentService : BaseService<StudentEntity>, IStudentService
{
   

    public StudentService(AppDbContext context, ILogger logger, IMapper mapper) : base(context, logger)
    {
    }

    public StudentService(AppDbContext context) : base(context)
    {

    }

    public new async Task<IEnumerable<StudentEntity>> GetAllAsync(QueryParametersDto dto)
    {
        return await Context.Students
            .Include(s => s.StudentCourses)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ToListAsync();
    }

    public async Task<StudentEntity?> GetByIdWithCoursesAsync(Guid id)
    {
        return await Context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(s => s.StudentId == id);
    }

    
}