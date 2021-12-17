using AutoMapper;
using DS.CineLabs.Application.Dtos.Movie;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Application.Services.MovieCategorie;
using DS.CineLabs.Application.Services.MovieDetails;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Common.Models.Movies;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.Movie
{
    public class MovieControllerTest
    {
        private readonly Mock<IMovieService> service;
        private readonly MoviesController controller;
        private readonly Mock<IMovieDetailsService> movieDetailsService;
        private readonly Mock<IMovieCategoriesService> movieCategoriesService;
        private readonly Mock<ICategoryService> categoryService;
        private static IMapper imapper;

        public MovieControllerTest()
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
            service = new Mock<IMovieService>();
            movieDetailsService = new Mock<IMovieDetailsService>();
            movieCategoriesService = new Mock<IMovieCategoriesService>();
            categoryService = new Mock<ICategoryService>();
            controller = new MoviesController(service.Object, imapper,movieDetailsService.Object,movieCategoriesService.Object,categoryService.Object);
        }

        [Fact]
        public void GetAllMovies_View()
        {
            var result = controller.GetAllMovies(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public  void CreateMovie_View()
        {
            var result =  controller.CreateMovie();
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateMovie_Post()
        {
            var movieModel = new MovieViewModel
            {
                Name = "SpiderMan",
                Description = "Great Movie",
                DetailsId = 1,
                Id = System.Guid.NewGuid(),
                selectedCategories = new List<int>() { 2,3}
                
            };
            var movie = imapper.Map<CreateMovieDto>(movieModel);
            service.Setup(s => s.Create(movie));
            var result = controller.CreateMovieModel(movieModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CreateMovie_InvalidModel()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.CreateMovieModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UpdateMovie_View()
        {
            var result = controller.UpdateMovieById(System.Guid.NewGuid());
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void UpdateMovieModel()
        {
            var movieModel = new UpdateMovieModel
            {
                Name = "Batman",
                Description="Great movie",
                DetailsId=2,
                Id=System.Guid.NewGuid()
            };

            var movie = imapper.Map<UpdateMovieDto>(movieModel);
            service.Setup(s => s.Update(movie));
            var result = controller.UpdateMovieModel(movieModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void UpdateMovieModel_InvalidModel()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.UpdateMovieModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteMovie_OkResult()
        {
            var result = controller.DeleteMovieByIdPost(System.Guid.NewGuid());

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
