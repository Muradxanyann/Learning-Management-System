using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> _logger;
    private readonly IServiceManager  _serviceManager;
    public StudentsController(ILogger<StudentsController> logger, IServiceManager serviceManager)
    {
        _logger = logger;
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _serviceManager.Student.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _serviceManager.Student.GetByIdAsync(id);
        
        if (entity is null)
            return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentForCreationDto dto)
    {
        var student = new StudentEntity
        {
            StudentId = Guid.NewGuid(),
            StudentName = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };
        await _serviceManager.Student.CreateAsync(student);
        await _serviceManager.SaveAsync();
        return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var answer = _serviceManager.Student.DeleteAsync(id);
        if (!answer.Result)
            return NotFound();
        _serviceManager.SaveAsync();
        return NoContent();
    }
    
    
}