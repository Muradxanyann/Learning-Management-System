using System.Linq.Expressions;
using Application.Filters;
using Domain;
using Domain.Entities;

namespace Application.Extensions;

public static class QueryableExtensions
{
    //Version1 - sorting
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string sortBy, string sortOrder)
    {
        if (string.IsNullOrWhiteSpace(sortBy))
            return query; // if sortBy prop is null

        var entityType = typeof(T); // gives student || course || student 
        var property = entityType.GetProperty(sortBy,
            System.Reflection.BindingFlags.IgnoreCase |
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Instance); // checking our T type has given sortBy prop ignoring cases, with reflection

        if (property == null)
            return query; 

        var parameter = Expression.Parameter(entityType, "x");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter); 
        // as ef core cant transform from delegate to sql, we are creating expression tree, like lambda

        string method = sortOrder.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";

        var resultExp = Expression.Call(typeof(Queryable), method,
            [entityType, property.PropertyType],
            query.Expression, Expression.Quote(orderByExp));

        return query.Provider.CreateQuery<T>(resultExp);
    }
    

    public static IQueryable<ApplicationUser> ApplyFilter(this IQueryable<ApplicationUser> query,
        UserFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.StudentName))
            query = query.Where(x => x.UserName!.Contains(filter.StudentName));
        
        if (!string.IsNullOrEmpty(filter.Email))
            query = query.Where(x => x.Email!.Contains(filter.Email));
        
        if  (!string.IsNullOrEmpty(filter.PhoneNumber))
            query = query.Where(x => x.PhoneNumber!.Contains(filter.PhoneNumber));
        return query;
    }

    public static IQueryable<LessonEntity> ApplyFilter(this IQueryable<LessonEntity> query,
        LessonFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.Contains(filter.Title));
        if (!string.IsNullOrEmpty(filter.Description))
            query = query.Where(x => x.Description.Contains(filter.Description));
        return query;
    }
    
    public static IQueryable<CourseEntity> ApplyFilter(this IQueryable<CourseEntity> query,
        CourseFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.Contains(filter.Title));
        if (!string.IsNullOrEmpty(filter.Description))
            query = query.Where(x => x.Description.Contains(filter.Description));
        return query;
    }
   
    
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PageResult pagination)
    {
        if (pagination.PageNumber <= 0) pagination.PageNumber = 1;
        if (pagination.PageSize <= 0) pagination.PageSize = 10;

        return query.Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);
    }
    
}
