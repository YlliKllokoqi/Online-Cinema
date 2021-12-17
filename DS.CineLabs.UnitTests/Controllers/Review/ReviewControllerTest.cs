using AutoMapper;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Common.Models.Review;
using DS.CineLabs.UI.Controllers;
using DS.CineLabs.UI.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Controllers.Review
{
    public class ReviewControllerTest
    {
        private readonly Mock<IReviewService> service;
        private readonly ReviewController controller;
        private static IMapper imapper;

        public ReviewControllerTest()
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
            service = new Mock<IReviewService>();
            controller = new ReviewController(service.Object, imapper);
        }
        [Fact]
        public void GetAllReviews_View()
        {
            var result = controller.GetAllReviews(1);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void DeleteReview_OkResult()
        {
            var result = controller.DeleteReviewByIdPost(1);

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
