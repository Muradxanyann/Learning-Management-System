using Application.DTOs.UserDto;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.ProfilesForMapping;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<ApplicationUser, StudentForResponseDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Courses,
                opt => opt.MapFrom(src => src.CoursesTaken));
        
        

        // DTO -> User (для создания)
        CreateMap<UserForCreationDto, ApplicationUser>();
    }
}