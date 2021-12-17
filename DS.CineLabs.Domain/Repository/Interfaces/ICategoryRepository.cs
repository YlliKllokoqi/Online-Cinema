using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
