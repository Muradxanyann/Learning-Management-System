using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public class CourseEntity
{
    public Guid CourseId { get; set; }
    public string Title { get; set; } =  null!;
    public string  Description { get; set; } = null!;
    public IList<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public IList<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();
    
    public CourseEntity() { }

    
    public CourseEntity(string title, string description)
    {
        Title = title;
        Description = description;
    }
}