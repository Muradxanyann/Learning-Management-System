using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure___Persistence.Configurations;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourseEntity>
{
    public void Configure(EntityTypeBuilder<StudentCourseEntity> builder)
    {
        builder.ToTable("student_course");

        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder.HasOne(sc => sc.Student)
            .WithMany(u => u.CoursesTaken)
            .HasForeignKey(sc => sc.StudentId)
            .HasPrincipalKey(u => u.Id);

        builder.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId)
            .HasPrincipalKey(c => c.CourseId);
    }
}