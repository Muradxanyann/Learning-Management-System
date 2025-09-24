namespace Domain.Entities;

public class StudentCourseEntity
{
    public string StudentId { get; set; } = null!;
    public ApplicationUser Student { get; set; } = null!;

    public Guid CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public bool IsCompleted { get; set; } = false;

    
    public StudentCourseEntity() { }

    public StudentCourseEntity(ApplicationUser student, CourseEntity course)
    {
        StudentId = student.Id;
        Student = student;
        
        CourseId = course.CourseId;
        Course = course;
        
        Created = DateTime.UtcNow;
        IsCompleted = false;
    }
}

