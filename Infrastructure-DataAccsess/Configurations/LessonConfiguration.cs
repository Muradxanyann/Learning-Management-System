using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure___Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.HasKey(s => s.LessonId);
        
        builder.
            HasOne(c => c.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(c => c.CourseId);
    }
}