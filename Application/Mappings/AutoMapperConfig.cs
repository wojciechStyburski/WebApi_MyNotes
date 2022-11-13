using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public static class AutoMapperConfig
{
    public static IMapper Initialize() => new MapperConfiguration(cfg =>
    {
        //Mapowanie encji Note
        cfg.CreateMap<Note, NoteDto>()
            .ForMember(dest => dest.LastModified, act => act.MapFrom(src => src.Detail.LastModified))
            .ForMember(dest => dest.Category, act => act.MapFrom(src => new CategoryDto
            {
                Id = src.Category.Id,
                Name = src.Category.Name
            }));
        
        cfg.CreateMap<CreateNoteDto, Note>();
        
        cfg.CreateMap<UpdateNoteDto, Note>();
        
        cfg.CreateMap<List<Note>, ResultDto<NoteDto>>()
            .ForMember(dest => dest.Items, act => act.MapFrom(src => src))
            .ForMember(dest => dest.TotalCount, act => act.MapFrom(src => src.Count));

        //Mapowanie encji Category
        cfg.CreateMap<Category, CategoryDto>();
        
        cfg.CreateMap<CategoryDto, Category>();
        
        cfg.CreateMap<CreateUpdateCategoryDto, Category>();
    })
    .CreateMapper();
}