using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
    public interface IMovieDetailsRepository
    {
        Task<IEnumerable<MovieDetails>> GetMovieDetails();
        Task<MovieDetails> GetMovieDetailsById(int id);
        void CreateMovieDetails(MovieDetails movieDetails);
        void Update(MovieDetails movieDetails);
        void Delete(int id);

    }
}
