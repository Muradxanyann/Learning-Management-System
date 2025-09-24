using Application.DTOs;
using Application.Filters;
using Domain;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService : IBaseService<ApplicationUser>
{
    
    public Task<IEnumerable<ApplicationUser>> GetAllAsync(QueryParametersDto dto, UserFilter filter, PageResult pagination);
    public Task<ApplicationUser?> GetByIdWithCoursesAsync(string id);
}

