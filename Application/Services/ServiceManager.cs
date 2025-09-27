using Application.Interfaces;
using Domain.Entities;
using Infrastructure___Persistence;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class ServiceManager  : IServiceManager
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    
    private ICourseService? _courseService;
    private ILessonService? _lessonService;
    private IUserService? _userService;
    private IStudentCourseService? _studentCourseService;
    public ServiceManager(AppDbContext context,  UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public ICourseService Course => _courseService ??= new CourseService(_context);
    public ILessonService Lesson => _lessonService ??= new LessonService(_context);
    public IUserService User => _userService ??= new UserService(_context);
    
    public IStudentCourseService StudentCourse => _studentCourseService ??= new StudentCourseService(_context, _userManager);
    public Task SaveAsync(CancellationToken ct) => _context.SaveChangesAsync(ct);
}