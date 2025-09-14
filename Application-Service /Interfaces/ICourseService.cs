using Domain;
using Service.DTOs;

namespace Service.Interfaces;

public interface ICourseService : IBaseService<CourseEntity>
{
    //Task<bool> AddLessonAsync(Guid courseId, LessonEntity lesson);
}