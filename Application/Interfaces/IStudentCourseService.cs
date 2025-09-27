using Domain;
using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentCourseService
{
    Task<StudentCourseEntity?> TakeCourseAsync(string userId, 
        Guid courseId, CancellationToken cancellationToken = default);
    Task<bool> CompleteCourseAsync(string userId, Guid courseId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<CourseEntity>> GetCoursesByUserAsync(string userId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<ApplicationUser>> GetStudentsByCourseAsync(Guid courseId,
        CancellationToken cancellationToken = default);
        
}