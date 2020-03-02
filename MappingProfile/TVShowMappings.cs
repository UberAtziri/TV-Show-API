using AutoMapper;
using WebApi.DTO;
using WebApi.Entities;

namespace WebApi.MappingProfile
{
    public class TVShowMappings : Profile
    {
        public TVShowMappings()
        {
            CreateMap<TVShowEntity, TVShowCreateDto>().ReverseMap();
            CreateMap<TVShowEntity, TVShowResponse>().ReverseMap();
            //CreateMap<TVShowGenre, TVShowGenreResponse>().ReverseMap();
            CreateMap<GenreEntity, GenreCreateDto>().ReverseMap();
            CreateMap<GenreResponse,GenreEntity>().ReverseMap();
        }
    }
}