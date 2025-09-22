namespace Application.Filters;

public class PagedResponse<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    
    public int TotalCount { get; set; }
}