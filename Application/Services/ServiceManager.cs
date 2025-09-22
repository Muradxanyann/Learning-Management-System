using Application.Interfaces;
using Infrastructure___Persistence;

namespace Application.Services;

public class ServiceManager  : IServiceManager
{
    private readonly AppDbContext _context;
    
    private ICourseService? _courseService;
    private ILessonService? _lessonService;
    private IStudentService? _userService;
    public ServiceManager(AppDbContext context)
    {
        _context = context;
    }

    public ICourseService Course => _courseService ??= new CourseService(_context);
    public ILessonService Lesson => _lessonService ??= new LessonService(_context);
    public IStudentService Student => _userService ??= new StudentService(_context);
    public Task SaveAsync() => _context.SaveChangesAsync();
}