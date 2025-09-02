namespace Domain;

public class LessonEntity
{
    public Guid LessonId { get; set; }
    public string Title { get; set; } =  null!;
    public string  Description { get; set; } = null!;
    public List<LessonCourse> LessonCourses { get; set; } = new List<LessonCourse>();
    
    public LessonEntity () { }

    public LessonEntity(string title, string description)
    {
        LessonId = Guid.NewGuid();
        Title = title;
        Description = description;
    }
}