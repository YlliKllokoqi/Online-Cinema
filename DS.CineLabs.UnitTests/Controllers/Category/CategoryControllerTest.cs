using AutoMapper;
using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.Category
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryService> service;
        private readonly CategoryController controller;
        private static IMapper imapper;

        public CategoryControllerTest()
        {
            if (imapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                imapper = mapper;
            }
            service = new Mock<ICategoryService>();
            controller = new CategoryController(service.Object, imapper);
        }

        [Fact]
        public void GetAllCategories_View()
        {
            var result = controller.GetAllCategories(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateCategory_View()
        {
            var result = controller.CreateCategory();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateCategory_Post()
        {
            var CategoryModel = new CreateCategoryModel
            {
                Name = "Action"
            };
            var category = imapper.Map<CreateCategoryDto>(CategoryModel);
            service.Setup(s => s.CreateCategory(category));
            var result = controller.CreateCategoryModel(CategoryModel);
            Assert.IsType<RedirectToActionResult>(result); 
        }

        [Fact]
        public void CreateCategory_InvalidModel()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.CreateCategoryModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UpdateCategory_View()
        {
            var result = controller.UpdateCategoryById(2);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void UpdateCategoryModel()
        {
            var categoryModel = new UpdateCategoryModel
            {
                Name = "Comedy"
            };

            var category = imapper.Map<UpdateCategoryDto>(categoryModel);
            service.Setup(s => s.UpdateCategory(category));
            var result = controller.UpdateCategoryModel(categoryModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void UpdateCategoryModel_InvalidModel()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.UpdateCategoryModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteCategory_OkResult()
        {
            var result = controller.DeleteCategoryByIdPost(1);

            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}
