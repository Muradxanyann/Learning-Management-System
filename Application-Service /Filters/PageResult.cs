namespace Service.Filters;

public class PageResult
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>(); 
    public int TotalCount { get; set; }             
    public int PageNumber { get; set; }                
    public int PageSize { get; set; }                            

    
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}