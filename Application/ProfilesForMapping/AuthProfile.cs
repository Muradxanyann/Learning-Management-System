using Application.DTOs.AuthenticationDto;
using AutoMapper;
using Domain.Entities;

namespace Application.ProfilesForMapping;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegistrationDto, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}