using DS.CineLabs.Application.Dtos;
using DS.CineLabs.Application.Dtos.MovieCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.MovieCategorie
{
    public interface IMovieCategoriesService
    {
        Task<IEnumerable<GetMovieCategoriesDto>> GetAll();
        void Create(CreateMovieCategoriesDto movieCategories);
    }
}
