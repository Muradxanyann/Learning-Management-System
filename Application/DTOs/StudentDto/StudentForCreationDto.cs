namespace Application.DTOs.StudentDto;

public record StudentForCreationDto
{
    public string StudentName { get; init; } =  null!;
    public string Email { get; init; } =  null!;
    public string PhoneNumber { get; init; } =  null!;
}