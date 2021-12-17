using AutoMapper;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Services.Categories;
using DS.CineLabs.Application.Services.Coupons;
using DS.CineLabs.Application.Services.MovieCategorie;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Application.Services.Ticket;
using DS.CineLabs.Common.Models.Home;
using DS.CineLabs.Infrastructure.Identity;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.Home
{
    public class HomeControllerTest
    {
        private readonly Mock<IMovieService> _movieService;
        private readonly Mock<ICategoryService> _categoryService;
        private readonly Mock<IMovieCategoriesService> _movieCategoriesService;
        private readonly Mock<IReviewService> _reviewService;
        private readonly IMapper _mapper;
        private readonly Mock<ITicketService> _ticketService;
        private readonly Mock<UserManager<AppUser>> _userManager;
        private readonly Mock<ICouponService> _couponService;
        private readonly HomeController controller;

        public HomeControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            var userStoreMock = new Mock<IUserStore<AppUser>>();

            _movieService = new Mock<IMovieService>();
            _categoryService = new Mock<ICategoryService>();
            _movieCategoriesService = new Mock<IMovieCategoriesService>();
            _reviewService = new Mock<IReviewService>();
            _ticketService = new Mock<ITicketService>();
            _couponService = new Mock<ICouponService>();
            _userManager = new Mock<UserManager<AppUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            


            controller = new HomeController(_movieService.Object, _mapper, _categoryService.Object, _movieCategoriesService.Object,
                _reviewService.Object,_ticketService.Object, _userManager.Object, _couponService.Object);
        }

        [Fact]
        public void Index_View()
        {
            var result = controller.Index("", "",1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Details_View()
        {
            var result = controller.Details(Guid.NewGuid());
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateReview()
        {
            DetailsViewModel model = new DetailsViewModel()
            {
                UserId = "1",
                FirstName = "Test",
                Description = "Test description",
                MovieId = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };

            var map = _mapper.Map<CreateReviewDto>(model);
            _reviewService.Setup(r => r.CreateReview(map));
            var result = controller.CreateReviewModel(model);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void CreateReview_InvalidModel()
        {
            controller.ModelState.AddModelError("error", "errorerror");
            var result = controller.CreateReviewModel(model: null);
            Assert.IsType<Task<IActionResult>>(result);
        }

    }
}
