using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure___Persistence;

public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        if (!await roleManager.RoleExistsAsync("Student"))
            await roleManager.CreateAsync(new IdentityRole("Student"));
        
        if (!await roleManager.RoleExistsAsync("Teacher"))
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
    }

    public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, IConfiguration config)
    {
        var adminConfig = config.GetSection("AdminUser");
        var email = adminConfig["Email"];
        var userName = adminConfig["UserName"];
        var password = adminConfig["Password"];

        var existingAdmin = await userManager.FindByEmailAsync(email!);
        if (existingAdmin == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, password!);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}