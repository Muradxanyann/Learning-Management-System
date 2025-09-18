namespace Service.DTOs;

public class QueryParametersDto
{
    public string? SortBy { get; set; } = "Id"; 
    public string SortOrder { get; set; } = "asc"; 
}