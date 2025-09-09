using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly IServiceManager  _serviceManager;
    private readonly ILogger<LessonController> _logger;


    public LessonController(IServiceManager serviceManager,  ILogger<LessonController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllLessons()
    {
        var lessons = await _serviceManager.Lesson.GetAllAsync();
        if (lessons.Count() == 0)
        {
            _logger.LogInformation("No lessons found");
        }
        return Ok(lessons);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(Guid id)
    {
        var lesson = await _serviceManager.Lesson.GetByIdAsync(id);
        if (lesson == null)
        {
            _logger.LogInformation("No lesson found");
            return NotFound();
        }
            
        return Ok(lesson);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLesson([FromBody] LessonForCreationDto dto)
    {
        var lesson = new LessonEntity
        {
            LessonId = new Guid(),
            Title = dto.Title,
            Description = dto.Description
        };
        await _serviceManager.Lesson.CreateAsync(lesson);
        await _serviceManager.SaveAsync();
        return CreatedAtAction(nameof(GetLessonById), new { id = lesson.LessonId }, lesson);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLesson(Guid id)
    {
        var lesson = await _serviceManager.Lesson.DeleteAsync(id);
        if (!lesson)
            return NotFound();
        await _serviceManager.SaveAsync();
        return NoContent();

    }
    
    
}