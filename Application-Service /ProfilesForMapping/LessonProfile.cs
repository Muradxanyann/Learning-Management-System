using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.ProfilesForMapping;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
        // Entity -> Response DTO
        CreateMap<LessonEntity, LessonForResponseDto>();

        // Create DTO -> Entity, не трогаем ключ (его генерирует БД/домен)
        CreateMap<LessonForCreationDto, LessonEntity>()
            .ForMember(dest => dest.LessonId, opt => opt.Ignore())
            .ForMember(dest => dest.Course, opt => opt.Ignore()); // если навигация не нужна сейчас
    }
}