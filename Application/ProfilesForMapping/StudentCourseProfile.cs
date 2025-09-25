using Application.DTOs.CourseDto;
using Application.DTOs.UserDto;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.ProfilesForMapping;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourseForCreationDto, ApplicationUser>();
        
        CreateMap<StudentCourseEntity, CourseForResponseDtoWithoutLessons>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Course.Title))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted));

    }
}