using AutoMapper;
using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.MovieCategories;
using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.MovieCategorie
{
    public class MovieCategoriesService : IMovieCategoriesService
    {
        private readonly IMovieCategoriesRepository _repository;
        private readonly IMapper _mapper;
        public MovieCategoriesService(IMovieCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateMovieCategoriesDto movieCategories)
        {
            var model = _mapper.Map<MovieCategories>(movieCategories);
            _repository.Create(model);
        }

        public async Task<IEnumerable<GetMovieCategoriesDto>> GetAll()
        {
            var movieCategories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<GetMovieCategoriesDto>>(movieCategories);
        }

    }
}
