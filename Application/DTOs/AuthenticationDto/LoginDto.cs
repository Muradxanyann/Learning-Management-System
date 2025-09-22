namespace Application.DTOs.AuthenticationDto;

public class LoginDto
{
    public required string Email { get; set; } 
    public required string  Password  { get; set; }
}