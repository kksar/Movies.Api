using AutoMapper;

namespace Movies.Api
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, Models.MovieWithDetailsDto>();
        }
    }
}
