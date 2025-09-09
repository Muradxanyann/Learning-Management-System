using Infrastructure___Persistence;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service;

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