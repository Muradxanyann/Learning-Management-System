using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.ProfilesForMapping;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
      
        CreateMap<LessonEntity, LessonForResponseDto>();

     
        CreateMap<LessonForCreationDto, LessonEntity>()
            .ForMember(dest => dest.LessonId, opt => opt.Ignore())
            .ForMember(dest => dest.Course, opt => opt.Ignore()); 
    }
}