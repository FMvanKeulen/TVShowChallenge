using AutoMapper;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Show, ShowDTO>().ReverseMap();
            CreateMap<Episode, EpisodeDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
        }
    }
}