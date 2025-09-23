using Application.DTOs.LessonDto;

namespace Application.DTOs.CourseDto;

public record CourseForResponseDto
{
    public Guid CourseId { get; init; }
    public string Title { get; init; } =  null!;
    public string  Description { get; init; } = null!;

    public List<LessonForResponseDto> Lessons { get; init; } = new();
}