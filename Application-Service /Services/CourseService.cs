using Domain;
using Infrastructure___Persistence;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service;

public class CourseService : BaseService<CourseEntity>, ICourseService
{
    public CourseService(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public CourseService(AppDbContext context) : base(context)
    {
    }
}
    