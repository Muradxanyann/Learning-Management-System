using Domain;

namespace Service.DTOs;

public record CourseForResponseDto
{
    public Guid CourseId { get; init; }
    public string Title { get; init; } =  null!;
    public string  Description { get; init; } = null!;

    public IList<LessonEntity> Lessons { get; init; } = [];
}