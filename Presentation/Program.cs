using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // важно, если у тебя классические контроллеры
builder.Services.AddEndpointsApiExplorer(); // для Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention());

builder.Services.AddScoped<IServiceManager, ServiceManager>(); 
builder.Services.AddScoped<ICourseService, CourseService>(); 
builder.Services.AddScoped<ILessonService, LessonService>(); 
builder.Services.AddScoped<IStudentService, StudentService>();



var app = builder.Build();
//app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();   

}

app.UseHttpsRedirection();
app.MapControllers(); 




app.Run();

