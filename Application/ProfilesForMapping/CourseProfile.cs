using Application.DTOs.CourseDto;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.ProfilesForMapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseEntity, CourseForResponseDto>();
        

        CreateMap<CourseForCreationDto, CourseEntity>()
            .ForMember<object>(dest => dest.StudentCourses, opt => opt.Ignore());


        //CreateMap<CourseEntity, CourseForResponseDtoWithoutLessons>();
    }
}