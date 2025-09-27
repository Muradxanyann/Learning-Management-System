using Application.Interfaces;
using Domain;
using Domain.Entities;
using Infrastructure___Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class StudentCourseService :  IStudentCourseService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _context;
    public StudentCourseService(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _context = context;
    }
    public async Task<StudentCourseEntity?> TakeCourseAsync(string userId, Guid courseId, CancellationToken ct)
    {
        var user = await _userManager.Users
            .Include(u => u.CoursesTaken)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(u => u.Id == userId, ct);

        if (user == null) 
            return null;

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId, ct);
        if (course == null) 
            return null;

        var exists = user.CoursesTaken.Any(sc => sc.CourseId == courseId);
        if (exists)
            return null;

        var studentCourse = new StudentCourseEntity
        {
            StudentId = userId,
            CourseId = courseId,
            Created = DateTime.UtcNow,
            IsCompleted = false
        };

        _context.Add(studentCourse);
        await _context.SaveChangesAsync(ct);

        return studentCourse;
    }

    public async Task<bool> CompleteCourseAsync(string userId, Guid courseId, CancellationToken ct)
    {
        var studentCourse = await _context.Set<StudentCourseEntity>()
            .FirstOrDefaultAsync(sc => sc.StudentId == userId && sc.CourseId == courseId, ct);

        if (studentCourse == null)
            return false;

        studentCourse.IsCompleted = true;
        await _context.SaveChangesAsync(ct);

        return true;
    }

    public async Task<IEnumerable<CourseEntity>> GetCoursesByUserAsync(string userId, CancellationToken ct)
    {
        return await _context.Set<StudentCourseEntity>()
            .Where(sc => sc.StudentId == userId)
            .Include(sc => sc.Course)
            .Select(sc => sc.Course)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<ApplicationUser>> GetStudentsByCourseAsync(Guid courseId,  CancellationToken ct)
    {
        return await _context.Set<StudentCourseEntity>()
            .Where(sc => sc.CourseId == courseId)
            .Include(sc => sc.Student)
            .Select(sc => sc.Student)
            .ToListAsync(ct);
    }
}