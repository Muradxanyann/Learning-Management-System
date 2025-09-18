using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.ProfilesForMapping;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourseForCreationDto, StudentCourse>();

    }
}