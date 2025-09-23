namespace Application.DTOs.LessonDto;

public record LessonForCreationDto
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}