using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Filters;
using Service.Interfaces;

namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> _logger;
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    [ActivatorUtilitiesConstructor]
    public StudentsController(ILogger<StudentsController> logger, IServiceManager serviceManager, IMapper mapper)
    {
        _logger = logger;
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametersDto dto, [FromQuery] StudentFilter filter, [FromQuery] PageResult pagination)
    {
        var students =
            await _serviceManager.Student.GetAllAsync(dto, filter, pagination);
        var studentDto = _mapper.Map<IList<StudentForResponseDto>>(students);
        return Ok(studentDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _serviceManager.Student.GetByIdAsync(id);
        if (student is null)
            return NotFound();

        var studentDto = _mapper.Map<StudentForResponseDto>(student);
        return Ok(studentDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentForCreationDto dto)
    {
        var student = _mapper.Map<StudentForCreationDto, StudentEntity>(dto);
        await _serviceManager.Student.CreateAsync(student);
        await _serviceManager.SaveAsync();
        var studentDto = _mapper.Map<StudentForResponseDto>(student);
        return CreatedAtAction(nameof(GetById), new { id = studentDto.StudentId }, studentDto);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var answer = await _serviceManager.Student.DeleteAsync(id);
        if (!answer)
            return NotFound();
        await _serviceManager.SaveAsync();
        return NoContent();
    }
}

/* For taking course, a lot of bugs inside)))

[HttpPost("{studentId}/courses")]
public async Task<IActionResult> TakeCourse(Guid studentId, [FromBody] TakeCourseDto dto)
{
    var student = await _serviceManager.Student.GetByIdAsync(studentId);
    var course = await _serviceManager.Course.GetByIdAsync(dto.CourseId);
    if (student is null || course is null)
        return NotFound();


    if (student.StudentCourses.All(sc => sc.CourseId != dto.CourseId))
    {
        var studentCourse = new StudentCourse
        {
            StudentId = studentId,
            CourseId = dto.CourseId,
            Created = DateTime.UtcNow,
            IsCompleted = false
        };
        student.StudentCourses.Add(studentCourse);
        await _serviceManager.SaveAsync();
    }

    var updatedStudent = await _serviceManager.Student.GetByIdWithCoursesAsync(studentId);

    var studentDto = _mapper.Map<StudentForResponseDto>(updatedStudent);
    return Ok(studentDto);
}
*/