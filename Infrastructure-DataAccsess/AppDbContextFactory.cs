using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Infrastructure___Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=Learning_Management_System;Username=postgres;Password=1111")
            .UseSnakeCaseNamingConvention();

        return new AppDbContext(optionsBuilder.Options);
    }
}