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

    public LessonController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllLessons()
    {
        var lessons = await _serviceManager.Lesson.GetAllAsync();
        return Ok(lessons);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(Guid id)
    {
        var lesson = await _serviceManager.Lesson.GetByIdAsync(id);
        if (lesson == null)
            return NotFound();
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