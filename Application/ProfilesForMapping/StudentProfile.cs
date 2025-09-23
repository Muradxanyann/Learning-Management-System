using Application.DTOs.StudentDto;
using AutoMapper;
using Domain;

namespace Application.ProfilesForMapping;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<StudentEntity, StudentForResponseDto>();

        CreateMap<StudentForCreationDto, StudentEntity>();

    }
}