namespace Service.DTOs;

public class StudentDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } =  null!;
    public string Email { get; set; } =  null!;
    public string PhoneNumber { get; set; } =  null!;
}