using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public ICollection<StudentCourseEntity> CoursesTaken { get; set; } = new List<StudentCourseEntity>();
}
