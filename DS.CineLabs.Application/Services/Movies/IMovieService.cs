using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMoviesDto>> GetAllMovies();
        Task<GetMoviesDto> GetMovieById(Guid id);
        void Create(CreateMovieDto movieDto);
        void Update(UpdateMovieDto movieDto);
        void Delete(Guid id);
        Task<IEnumerable<GetMoviesDto>> GetMoviesBySearchOrCategory(string category, string search);
        Task<IEnumerable<GetMoviesDto>> GetComingSoonMovies();
    }
}
