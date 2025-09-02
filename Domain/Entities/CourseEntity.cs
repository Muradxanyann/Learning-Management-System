namespace Domain;

public class CourseEntity
{
    public Guid CourseId { get; set; }
    public string Title { get; set; } =  null!;
    public string  Description { get; set; } = null!;
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    
    public List<LessonEntity> Lessons { get; set; } = new List<LessonEntity>();
    
    public CourseEntity() { }

    public CourseEntity(string title, string description)
    {
        Title = title;
        Description = description;
    }
}