using AutoMapper;
using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<DS.CineLabs.Domain.Entities.Movie>(movieDto);
            _repository.CreateMovie(movie);
        }

        public void Delete(Guid id)
        {
            _repository.DeleteMovie(id);
        }

        public async Task<IEnumerable<GetMoviesDto>> GetAllMovies()
        {
            var movies = await _repository.GetAllMovies();
            return _mapper.Map<IEnumerable<GetMoviesDto>>(movies);
        }

        public async Task<IEnumerable<GetMoviesDto>> GetComingSoonMovies()
        {
            var movies = await _repository.GetComingSoonMovies();
            return _mapper.Map<IEnumerable<GetMoviesDto>>(movies);
        }

        public async Task<GetMoviesDto> GetMovieById(Guid id)
        {
            var movie = await _repository.GetMovieById(id);
            return _mapper.Map<GetMoviesDto>(movie);
        }

        public async Task<IEnumerable<GetMoviesDto>> GetMoviesBySearchOrCategory(string category, string search)
        {
            var movie = await _repository.GetMoviesBySearchOrCategory(category, search);
            return _mapper.Map<IEnumerable<GetMoviesDto>>(movie);
        }

        public void Update(UpdateMovieDto movieDto)
        {
            var updateMovie = _mapper.Map<DS.CineLabs.Domain.Entities.Movie>(movieDto);
            _repository.UpdateMovie(updateMovie);
        }
    }
}
