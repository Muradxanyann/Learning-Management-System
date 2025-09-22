using Application.DTOs;
using Application.DTOs.CourseDto;
using Application.Filters;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IServiceManager  _serviceManager;
    private readonly ILogger<CourseController> _logger;
    private readonly IMapper _mapper;

    [ActivatorUtilitiesConstructor]
    public CourseController(IServiceManager serviceManager,  ILogger<CourseController> logger,  IMapper mapper)
    {
        _serviceManager = serviceManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCourses(
        [FromQuery] QueryParametersDto dto, 
        [FromQuery] CourseFilter filter, 
        [FromQuery] PageResult pagination)
    {
        var courses = await _serviceManager.Course.GetAllAsync(dto, filter, pagination);
        var courseDos = _mapper.Map<List<CourseForResponseDto>>(courses);
        return Ok(courseDos);
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
        
        var courseDto = _mapper.Map<CourseForResponseDto>(course);
        return Ok(courseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseForCreationDto dto)
    {
        var course = _mapper.Map<CourseEntity>(dto);
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