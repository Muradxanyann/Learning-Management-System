namespace Service.DTOs;

public record LessonForCreationDto
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}