using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public class CourseEntity
{
    public Guid CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    
    public ICollection<StudentCourseEntity> StudentCourses { get; set; } = new List<StudentCourseEntity>();

    public ICollection<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();

    
    public CourseEntity() { }

    
    public CourseEntity(string title, string description)
    {
        Title = title;
        Description = description;
    }
}