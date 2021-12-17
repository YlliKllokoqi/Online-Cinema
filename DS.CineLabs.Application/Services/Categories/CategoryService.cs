using AutoMapper;
using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _repository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
        }

        public async Task<IEnumerable<GetCategoriesDto>> GetAllCategories()
        {
            var categories = await _repository.GetAllCategories();
            return _mapper.Map<IEnumerable<GetCategoriesDto>>(categories);
        }

        public async Task<GetCategoriesDto> GetCategoryById(int id)
        {
            var category = await _repository.GetCategoryById(id);
            return _mapper.Map<GetCategoriesDto>(category);
        }

        public void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var updateCategory = _mapper.Map<Category>(categoryDto);
            _repository.UpdateCategory(updateCategory);
        }
    }
}
