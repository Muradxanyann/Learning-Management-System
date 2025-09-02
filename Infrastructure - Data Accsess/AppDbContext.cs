using Domain;
using Infrastructure___Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure___Persistence;

public class AppDbContext :  DbContext
{
    public DbSet<CourseEntity> Courses { get; set; } = null!;
    
    public DbSet<LessonEntity> Lessons { get; set; } = null!;
    
    public DbSet<StudentEntity> Students { get; set; } = null!;
    
    public AppDbContext (DbContextOptions<AppDbContext> options) : base (options){ }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    
}