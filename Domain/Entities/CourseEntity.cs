namespace Domain;

public class CourseEntity
{
    public Guid CourseId { get; set; }
    public string Title { get; set; } =  null!;
    public string  Description { get; set; } = null!;
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public List<LessonCourse> LessonCourses { get; set; } = new List<LessonCourse>();
    
    public CourseEntity() { }

    public CourseEntity(string title, string description)
    {
        Title = title;
        Description = description;
    }
}