using Application.DTOs;
using Application.Extensions;
using Application.Filters;
using Application.Interfaces;

using Domain.Entities;
using Infrastructure___Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;



namespace Application.Services;

public class UserService : BaseService<ApplicationUser>, IUserService
{
    
    public UserService(AppDbContext context, ILogger logger) : base(context, logger)
    {
        
    }

    public UserService(AppDbContext context) : base(context)
    {
        
    }

   

    public  async Task<IEnumerable<ApplicationUser>> GetAllAsync(
        QueryParametersDto dto,
        UserFilter filter,
        PageResult pagination)
    {
        var query = 
            Context.Users
            .AsNoTracking()
            .Include(u => u.CoursesTaken)
                .ThenInclude(c => c.Course)
            .ApplyFilter(filter)
            .ApplySort(dto.SortBy!, dto.SortOrder)
            .ApplyPagination(pagination);
        

        return await query.ToListAsync();
    }

   
    public async Task<ApplicationUser?> GetByIdWithCoursesAsync(string id)
    {
        return await Context.Users
            .AsNoTracking()
            .Include(s => s.CoursesTaken)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    
}