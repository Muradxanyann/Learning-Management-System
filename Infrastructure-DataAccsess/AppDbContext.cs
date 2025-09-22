using Domain;
using Domain.Entities;
using Infrastructure___Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure___Persistence;

public class AppDbContext :  IdentityDbContext<ApplicationUser>
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base (options){ }
    public DbSet<CourseEntity> Courses { get; set; } = null!;
    
    public DbSet<LessonEntity> Lessons { get; set; } = null!;
    
    public DbSet<StudentEntity> Students { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
}