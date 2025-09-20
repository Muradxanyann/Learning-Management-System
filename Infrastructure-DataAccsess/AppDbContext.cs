using Domain;
using Infrastructure___Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
    
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Строка подключения должна совпадать с appsettings.json
            optionsBuilder.UseNpgsql("Host=localhost;Database=Learning_Management_System;Username=postgres;Password=1111");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    
}