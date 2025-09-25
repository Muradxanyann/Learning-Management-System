namespace Application.DTOs.CourseDto;

public class CourseForResponseDtoWithoutLessons
{
    public Guid CourseId { get; init; }
    public string Title { get; init; } =  null!;
    public bool IsCompleted { get; init; }
}