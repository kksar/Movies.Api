using AutoMapper;

namespace Movies.Api.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, Models.MovieWithDetailsDto>();
            CreateMap<Entities.Movie, Models.MovieDto>();
            CreateMap<Entities.Language, Models.LanguageDto>();
        }
    }
}
