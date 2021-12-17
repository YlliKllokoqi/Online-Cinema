using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.MovieDetails
{
    public interface IMovieDetailsService
    {
        Task<IEnumerable<GetMovieDetailsDto>> GetMovieDetails();
        Task<GetMovieDetailsDto> GetMovieDetailsById(int id);
        void Create(CreateMovieDetailsDto createMovieDetailsDto);
        void Update(UpdateMovieDetailsDto updateMovieDetailsDto);
        void Delete(int id);
    }
}
