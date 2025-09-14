using Domain;

namespace Service.DTOs;

public record StudentForResponseDto
{
    public Guid StudentId { get; init; }
    public string StudentName { get; init; } =  null!;
    public string Email { get; init; } =  null!;
    public string PhoneNumber { get; init; } =  null!;
    public IList<StudentCourse> StudentCourses { get; init; } = [];
}