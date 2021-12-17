using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
    public interface IMovieCategoriesRepository
    {
        Task<IEnumerable<MovieCategories>> GetAll();
        void Create(MovieCategories movieCategories);

    }
}
