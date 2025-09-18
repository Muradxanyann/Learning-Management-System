using System.Linq.Expressions;
namespace Service.Extensions;

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
    
    //Version1 - filtring
    
  //  public static IQueryable<T> ApplyFilt
   
    
    
}
