using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure___Persistence.Configurations;

public class StudentConfiguration :  IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("students");
        builder.HasKey(s => s.StudentId);
        
        builder
            .HasMany(c => c.StudentCourses)
            .WithOne(sc => sc.Student)
            .HasForeignKey(sc => sc.StudentId);
        
        builder
            .HasIndex(t => t.Email)
            .IsUnique();
    }
}