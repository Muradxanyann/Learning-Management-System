using Application.DTOs.StudentDto;
using AutoMapper;
using Domain;

namespace Application.ProfilesForMapping;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourseForCreationDto, StudentCourse>();

    }
}