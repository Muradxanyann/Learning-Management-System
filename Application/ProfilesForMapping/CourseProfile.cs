using Application.DTOs.AuthenticationDto;
using Application.DTOs.CourseDto;
using AutoMapper;
using Domain;
using Domain.Entities;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.ProfilesForMapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseEntity, CourseForResponseDto>();
        

        CreateMap<CourseForCreationDto, CourseEntity>()
            .ForMember<object>(dest => dest.StudentCourses, opt => opt.Ignore());
        
        CreateMap<CourseEntity, CourseForResponseDtoWithoutLessons>();
        
        
    }
}

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegistrationDto, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}

