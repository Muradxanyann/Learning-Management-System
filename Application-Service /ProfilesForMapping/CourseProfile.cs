using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.ProfilesForMapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseEntity, CourseForResponseDto>();
        

        CreateMap<CourseForCreationDto, CourseEntity>()
            .ForMember(dest => dest.StudentCourses, opt => opt.Ignore());
        
        CreateMap<CourseEntity, CourseForResponseDtoWithoutLessons>();
        
        
    }
}
