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

    }
}