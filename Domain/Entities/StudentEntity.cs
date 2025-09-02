namespace Domain;

public class StudentEntity
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } =  null!;
    public string Email { get; set; } =  null!;
    public string PhoneNumber { get; set; } =  null!;
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    
    public StudentEntity() { }

    public StudentEntity(string studentName, string email, string phoneNumber)
    {
        StudentId = Guid.NewGuid();
        StudentName = studentName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}