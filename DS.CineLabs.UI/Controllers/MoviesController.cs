using AutoMapper;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Dtos.MovieCategories;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Application.Services.MovieCategorie;
using DS.CineLabs.Application.Services.MovieDetails;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace DS.CineLabs.UI.Controllers
{
    [Authorize(Roles = RolesModel.AdminRole)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        private readonly IMovieDetailsService _movieDetailsService;
        private readonly IMovieCategoriesService _movieCategoriesService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public MoviesController(IMovieService service, IMapper mapper,
            IMovieDetailsService movieDetailsService,
            IMovieCategoriesService movieCategoriesService,
            ICategoryService categoryService)
        {
            _service = service;
            _mapper = mapper;
            _movieDetailsService = movieDetailsService;
            _categoryService = categoryService;
            _movieCategoriesService = movieCategoriesService;
        }

        [HttpGet]
        [Route("Movies")]
        public async Task<IActionResult> GetAllMovies(int? page)
        {
            var movies = await _service.GetAllMovies();
            var model = _mapper.Map<IEnumerable<GetMovieModel>>(movies);
            return View(model.ToPagedList(page ?? 1, 5));

        }

        [HttpGet]
        [Route("Movies/Create")]
        public async Task<IActionResult> CreateMovie()
        {
            var moviedetailsList = await _movieDetailsService.GetMovieDetails();
            ViewBag.MovieDetails = new SelectList(moviedetailsList.ToPagedList(1,5), "Id", "Movie_Name");
            var categoryList = await _categoryService.GetAllCategories();
            MovieViewModel model = new MovieViewModel
            {
                CategoryList = new MultiSelectList(categoryList, "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateMovieModel(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movieMap = _mapper.Map<CreateMovieDto>(model);
                _service.Create(movieMap);

                foreach (var selectedId in model.selectedCategories)
                {
                    _movieCategoriesService.Create(new CreateMovieCategoriesDto
                    {
                        MovieId = movieMap.Id,
                        CategoryId = selectedId,
                    });
                }
                return RedirectToAction("GetAllMovies");
            }
            return View("CreateMovie");
        }

        [HttpGet]
        [Route("Movies/Delete/{id}")]
        public async Task<IActionResult> DeleteMovieById(Guid id)
        {
            var movie = await _service.GetMovieById(id);
            var modelToReturn = _mapper.Map<GetMovieModel>(movie);
            return View(modelToReturn);
        }

        [HttpPost]
        public IActionResult DeleteMovieByIdPost(Guid id)
        {
            _service.Delete(id);
            return RedirectToAction("GetAllMovies");
        }


        [HttpGet]
        [Route("Movies/Edit/{id}")]
        public async Task<IActionResult> UpdateMovieById(Guid id)
        {
            var moviedetailsList = await _movieDetailsService.GetMovieDetails();
            ViewBag.MovieDetails = new SelectList(moviedetailsList, "Id", "Movie_Name");
            var movie = await _service.GetMovieById(id);
            var model = _mapper.Map<UpdateMovieModel>(movie);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMovieModel(UpdateMovieModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedMovie = _mapper.Map<UpdateMovieDto>(model);
                _service.Update(updatedMovie);
                return RedirectToAction("GetAllMovies");
            }
            return View("UpdateMovieById");
        }
    }
}
