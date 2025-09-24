using Domain;
using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentCourseService
{
    Task<StudentCourseEntity?> TakeCourseAsync(string userId, Guid courseId);
    Task<bool> CompleteCourseAsync(string userId, Guid courseId);
    Task<IEnumerable<CourseEntity>> GetCoursesByUserAsync(string userId);
    Task<IEnumerable<ApplicationUser>> GetStudentsByCourseAsync(Guid courseId);
    
    //Task<bool> AddStudentCourseAsync(StudentCourseEntity studentCourse);
}