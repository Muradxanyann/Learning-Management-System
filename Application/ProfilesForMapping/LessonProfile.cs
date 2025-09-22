using Application.DTOs.LessonDto;
using AutoMapper;
using Domain;

namespace Application.ProfilesForMapping;

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