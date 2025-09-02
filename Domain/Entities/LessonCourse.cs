namespace Domain;

public class LessonCourse
{
    public Guid LessonId { get; set; }
    public LessonEntity Lesson { get; set; } = null!;
    
    public Guid CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
    
    public LessonCourse() { }

    public LessonCourse(LessonEntity lesson,  CourseEntity course)
    {
        LessonId = lesson.LessonId;
        Lesson = lesson;
        
        CourseId = course.CourseId;
        Course = course;
        
        
    }
}