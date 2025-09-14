using Domain;

namespace Service.DTOs;

public record CourseForCreationDto   
{
    public string Title { get; init; } =  null!;
    public string  Description { get; init; } = null!;
}