namespace Application.Interfaces;

public interface IServiceManager
{
    ICourseService Course { get; }
    ILessonService  Lesson { get; }
    IUserService User { get; }
    IStudentCourseService  StudentCourse { get; }
    Task SaveAsync(CancellationToken ct);
}

