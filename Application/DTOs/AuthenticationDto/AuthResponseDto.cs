namespace Application.DTOs.AuthenticationDto;

public class AuthResponseDto
{
    public string Token { get; set; }  = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public string[] Roles { get; set; } = [];
}