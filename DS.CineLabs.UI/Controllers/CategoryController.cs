using AutoMapper;
using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Common.Models.Category;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace DS.CineLabs.UI.Controllers
{
    [Authorize(Roles = RolesModel.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Category")]
        public async Task<IActionResult> GetAllCategories(int? page)
        {

            var category = await _service.GetAllCategories();
            var model = _mapper.Map<IEnumerable<GetCategoryModel>>(category);
            return View(model.ToPagedList(page ?? 1,8));
        }


        [HttpGet]
        [Route("Category/Create")]
        public IActionResult CreateCategory()
        {
            return View(new CreateCategoryModel());
        }

        [HttpPost]
        public IActionResult CreateCategoryModel(CreateCategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var category = _mapper.Map<CreateCategoryDto>(model);
                _service.CreateCategory(category);
                return RedirectToAction("GetAllCategories");
            }
            return View("CreateCategory");
        }


        [HttpGet]
        [Route("Category/Delete/{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var category = await _service.GetCategoryById(id);
            var modelToReturn = _mapper.Map<GetCategoryModel>(category);
            return View(modelToReturn);
        }

        [HttpPost]
        public IActionResult DeleteCategoryByIdPost(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("GetAllCategories");
        }


        [HttpGet]
        [Route("Category/Edit/{id}")]
        public async Task<IActionResult> UpdateCategoryById(int id)
        {
            var category = await _service.GetCategoryById(id);
            var model = _mapper.Map<UpdateCategoryModel>(category);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCategoryModel(UpdateCategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var updated = _mapper.Map<UpdateCategoryDto>(model);
                _service.UpdateCategory(updated);
                return RedirectToAction("GetAllCategories");
            }
            return View("UpdateCategoryById");
        }
    }
}
