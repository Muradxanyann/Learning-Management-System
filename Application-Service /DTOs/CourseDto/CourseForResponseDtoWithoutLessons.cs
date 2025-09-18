namespace Service.DTOs;

public class CourseForResponseDtoWithoutLessons
{
    public Guid CourseId { get; init; }
    public string Title { get; init; } =  null!;
    public string  Description { get; init; } = null!;
}