using Domain;
using Infrastructure___Persistence;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.DTOs;
using Service.Interfaces;
using Service.ProfilesForMapping;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention());

builder.Services.AddScoped<IServiceManager, ServiceManager>(); 
builder.Services.AddScoped<ICourseService, CourseService>(); 
builder.Services.AddScoped<ILessonService, LessonService>(); 
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddAutoMapper(typeof(LessonProfile).Assembly);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();   

}

app.UseHttpsRedirection();
app.MapControllers(); 




app.Run();

