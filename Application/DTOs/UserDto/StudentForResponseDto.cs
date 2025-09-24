using Application.DTOs.CourseDto;

namespace Application.DTOs.UserDto;

public record StudentForResponseDto
{
    public string Id { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public List<CourseForResponseDtoWithoutLessons> Courses { get; init; } = new();
}