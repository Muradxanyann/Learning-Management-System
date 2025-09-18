using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.ProfilesForMapping;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<StudentEntity, StudentForResponseDto>();

        CreateMap<StudentForCreationDto, StudentEntity>();

    }
}