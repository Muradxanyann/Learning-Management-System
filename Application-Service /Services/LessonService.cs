using Domain;
using Infrastructure___Persistence;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service;

public class LessonService : BaseService<LessonEntity>, ILessonService
{
    public LessonService(AppDbContext context, ILogger logger ) : base(context, logger) {}

    public LessonService(AppDbContext context) : base(context)
    {
       
    }
}