using AutoMapper;
using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Application.Services.MovieDetails;
using DS.CineLabs.Common.Models.MovieDetails;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.MovieDetails
{
    public class MovieDetailsControllerTest
    {
        private readonly Mock<IMovieDetailsService> service;
        private readonly MovieDetailsController controller;
        private readonly IMapper imapper;

        public MovieDetailsControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            imapper = mapper;

            service = new Mock<IMovieDetailsService>();
            controller = new MovieDetailsController(service.Object, imapper);
        }

        [Fact]
        public void GetAllMovieDetails_View()
        {
            var result = controller.GetAllMovieDetails(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateMovieDetails_View()
        {
            var result = controller.CreateMovieDetails();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateMovieDetails_Post()
        {
            var MovieDetailsModel = new CreateMovieDetailsModel
            {
                Movie_Name = "The Dark Knight",
                PhotoPathFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")),
                PhotoPath = "sss",
                Premiere = DateTime.Now,
                CoverFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")),
                CoverPath = "ssss",
                Director = "Christopher Nolan",
                Actors = "Christian Bale, Heath Ledger, Gary Oldman",
                Country = "USA",
                PG = "16+",
                Distributor = "Warner Bros",
                Length = 152,
                Schedule = "Friday 12 - 20:45",
                Trailer = "https://www.youtube.com/embed/EXeTwQWrcwY"
            };

            var MovieDetail = imapper.Map<CreateMovieDetailsDto>(MovieDetailsModel);
            service.Setup(s => s.Create(MovieDetail));
            var result = controller.CreateMovieDetailsModel(MovieDetailsModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CreateMovieDetailsModel_InvalidState()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.CreateMovieDetailsModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UpdateMovieDetails_View()
        {
            var result = controller.UpdateMovieDetailsById(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void UpdateMovieDetails_Post()
        {
            var MovieDetailsModel = new UpdateMovieDetailsModel
            {
                Movie_Name = "The Dark Knight",
                PhotoPath = "sss",
                Premiere = DateTime.Now,
                CoverPath = "ssss",
                Director = "Christopher Nolan",
                Actors = "Christian Bale, Heath Ledger, Gary Oldman",
                Country = "USA",
                PG = "16+",
                Distributor = "Warner Bros",
                Length = 152,
                Schedule = "Friday 12 - 20:45",
                Trailer = "https://www.youtube.com/embed/EXeTwQWrcwY"
            };

            var MovieDetail = imapper.Map<UpdateMovieDetailsDto>(MovieDetailsModel);
            service.Setup(s => s.Update(MovieDetail));
            var result = controller.UpdateMovieDetailsModel(MovieDetailsModel);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void UpdateMovieDetails_InvalidState()
        {
            controller.ModelState.AddModelError("error", "some error");
            var result = controller.UpdateMovieDetailsModel(model: null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteMovieDetail_OkResult()
        {
            var result = controller.DeleteMovieDetailsByIdPost(1);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
