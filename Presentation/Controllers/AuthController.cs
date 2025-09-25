using Application.DTOs.AuthenticationDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;


    public AuthController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService,
        IMapper mapper)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
            return BadRequest("User already exists");
        
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email
        };
        // var user = _mapper.Map<ApplicationUser>(dto); -- this version is also acceptable
        

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);
        
        if (!await _roleManager.RoleExistsAsync("Student"))
            await _roleManager.CreateAsync(new IdentityRole("Student"));

        await _userManager.AddToRoleAsync(user, "Student");

        return Ok(new
        {
            Message = "Registration Successful",
            Email = user.Email,
            Role = "Student"
        });
    }

    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        
        if (user == null)
            return Unauthorized("Invalid credentials");
        Console.WriteLine("Passed email");
        
        var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!passwordValid)
            return Unauthorized("Invalid credentials"); 
        


        var tokenDto = await _tokenService.CreateTokenAsync(user);
        return Ok(tokenDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("Student");
        return Ok(users);
    }
    
}