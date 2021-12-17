using DS.CineLabs.Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoriesDto>> GetAllCategories();
        Task<GetCategoriesDto> GetCategoryById(int id);
        void CreateCategory(CreateCategoryDto categoryDto);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        void DeleteCategory(int id);
    }
}
