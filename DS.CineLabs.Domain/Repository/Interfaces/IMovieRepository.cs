using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(Guid id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Guid id);
        Task<IEnumerable<Movie>> GetMoviesBySearchOrCategory(string category, string search);
        Task<IEnumerable<Movie>> GetComingSoonMovies();
    }
}
