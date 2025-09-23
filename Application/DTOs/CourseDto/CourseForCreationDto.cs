namespace Application.DTOs.CourseDto;

public record CourseForCreationDto   
{
    public string Title { get; init; } =  null!;
    public string  Description { get; init; } = null!;
}