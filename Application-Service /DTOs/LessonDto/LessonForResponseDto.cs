public record LessonForResponseDto
{
    public Guid LessonId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    
}