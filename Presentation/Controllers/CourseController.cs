using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IServiceManager  _serviceManager;
    private readonly ILogger<CourseController> _logger;


    public CourseController(IServiceManager serviceManager,  ILogger<CourseController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _serviceManager.Course.GetAllAsync();
        if (courses.Count() == 0)
        {
            _logger.LogInformation("No courses found");
        }
        return Ok(courses);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        var course = await _serviceManager.Course.GetByIdAsync(id);
        if (course == null)
        {
            _logger.LogInformation($"Entity with id {id} was not found");
            return NotFound();
        }
            
        return Ok(course);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseForCreationDto dto)
    {
        var course = new CourseEntity
        {
            CourseId = new Guid(),
            Title = dto.Title,
            Description = dto.Description
        };
        await _serviceManager.Course.CreateAsync(course);
        await _serviceManager.SaveAsync();
        return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        var course = await _serviceManager.Course.DeleteAsync(id);
        if (!course)
            return NotFound();
        await _serviceManager.SaveAsync();
        return NoContent();

    }
    
    
}