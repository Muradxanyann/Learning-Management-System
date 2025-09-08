namespace Service.Interfaces;

public interface IServiceManager
{
    ICourseService Course { get; }
    ILessonService  Lesson { get; }
    IStudentService Student { get; }
    Task SaveAsync();
}