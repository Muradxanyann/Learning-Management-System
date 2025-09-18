using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class StudentCourse
{
 
    public Guid StudentId { get; set; }
    public StudentEntity Student { get; set; } = null!;
    
    public Guid CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
    
    public DateTime Created { get; set; }
    public bool IsCompleted { get; set; }
    
    public StudentCourse() { }

    public StudentCourse(StudentEntity student, CourseEntity course)
    {
        StudentId = student.StudentId;
        Student = student;
        
        CourseId = course.CourseId;
        Course = course;
        
        Created = DateTime.UtcNow;
        IsCompleted = false;
    }
}