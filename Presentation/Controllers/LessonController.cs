using AutoMapper;
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
    private readonly IMapper _mapper;


    public LessonController(IServiceManager serviceManager,  ILogger<LessonController> logger, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllLessons([FromQuery]  QueryParametersDto dto)
    {
        var lessons = await _serviceManager.Lesson.GetAllAsync(dto);
        if (!lessons.Any())
        {
            _logger.LogInformation("No lessons found");
        }
        
        var responses = _mapper.Map<List<LessonForResponseDto>>(lessons);
        return Ok(responses);
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
        
        var dto = _mapper.Map<LessonForResponseDto>(lesson);
        return Ok(dto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLesson(Guid courseId, [FromBody] LessonForCreationDto dto)
    {
        var course = await _serviceManager.Course.GetByIdAsync(courseId);
        if (course == null)
        {
            _logger.LogInformation("No course found with id {courseId}", courseId);
            return NotFound();
        }
        var lesson = _mapper.Map<LessonEntity>(dto);
        
        course.Lessons.Add(lesson);
        await _serviceManager.Lesson.CreateAsync(lesson);
        Console.WriteLine(course.Lessons.Count);
        
        await _serviceManager.SaveAsync();

        var responseDto = _mapper.Map<LessonForResponseDto>(lesson);
        return CreatedAtAction(nameof(GetLessonById), new { id = responseDto.LessonId }, responseDto);
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