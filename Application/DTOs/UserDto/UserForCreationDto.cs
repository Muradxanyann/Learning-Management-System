namespace Application.DTOs.UserDto;

public record UserForCreationDto
{
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Password { get; init; } = null!;
}