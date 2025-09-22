namespace Application.DTOs.StudentDto;

public record StudentCourseForCreationDto
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    
    public DateTime Created { get; set; }
    public bool IsCompleted { get; set; }
}