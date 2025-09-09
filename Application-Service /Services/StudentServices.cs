using Domain;
using Infrastructure___Persistence;
using Microsoft.Extensions.Logging;
using Service;
using Service.Interfaces;

public class StudentService : BaseService<StudentEntity>, IStudentService
{
    public StudentService(AppDbContext context, ILogger logger) : base(context, logger) { }

    public StudentService(AppDbContext context) : base(context)
    {
    }
}