using System.Security.Claims;
using Application.DTOs;
using Application.DTOs.UserDto;
using Application.Extensions;
using Application.Filters;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    [ActivatorUtilitiesConstructor]
    public UserController(ILogger<UserController> logger, IMapper mapper,  UserManager<ApplicationUser> userManager,  IServiceManager serviceManager)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParametersDto dto,
        [FromQuery] UserFilter filter,
        [FromQuery] PageResult pagination)
    {
        var users = await _serviceManager.User.GetAllAsync(dto, filter, pagination);
        if (!users.Any())
            return NotFound();
        
        var response = _mapper.Map<IEnumerable<StudentForResponseDto>>(users);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        var studentDto = _mapper.Map<StudentForResponseDto>(user);
        return Ok(studentDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserForCreationDto dto)
    {
        var user = _mapper.Map<ApplicationUser>(dto);

        var result = await _userManager.CreateAsync(user, dto.Password); 
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        var studentDto = _mapper.Map<StudentForResponseDto>(user);
        return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }
    
    
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Student")]
    
    [HttpPost("/takeCourse")]
    public async Task<IActionResult> TakeCourse([FromQuery] Guid courseId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Unauthorized();

        var result = await _serviceManager.StudentCourse.TakeCourseAsync(userId, courseId);
        if (result == null)
            return BadRequest("Course not found or already taken.");

        return Ok(new { Message = "Course taken successfully", result.CourseId });
    }

    /*[HttpPost("{courseId}/complete")]
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> CompleteCourse(Guid courseId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Unauthorized();
        
        var success = await _serviceManager.StudentCourse.CompleteCourseAsync(userId, courseId);

        return success ? Ok("Course completed!") : BadRequest("Course not found.");
    }*/
}

