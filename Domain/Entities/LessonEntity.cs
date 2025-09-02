namespace Domain;

public class LessonEntity
{
    public Guid LessonId { get; set; }
    public string Title { get; set; } =  null!;
    public string  Description { get; set; } = null!;
    
    public Guid CourseId { get; set; }
    
    public CourseEntity Course { get; set; } = null!;
    
    public LessonEntity () { }

    public LessonEntity(string title, string description)
    {
        LessonId = Guid.NewGuid();
        Title = title;
        Description = description;
    }
}