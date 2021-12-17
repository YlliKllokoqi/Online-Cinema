using DS.CineLabs.Application.Validations.Review;
using DS.CineLabs.Common.Models.Home;
using DS.CineLabs.Common.Models.Review;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Review
{
    public class CreateReviewValidationTest
    {
        private readonly CreateReviewValidation validation;
        public CreateReviewValidationTest()
        {
            validation = new CreateReviewValidation();
        }

        [Fact]
        public void Review_Return_Null()
        {
            //arrange
            var reviewModel = new DetailsViewModel
            {
                Description = "",
                MovieId = new Guid()
            };

            //act
            var result = validation.Validate(reviewModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Review_Return_Value()
        {
            //arrange
            var reviewModel = new DetailsViewModel
            {
                Description = "descriptionpopwqopwoqpowqpwopqwoqwpoqwqpowq",
                MovieId = new Guid()
            };

            //act
            var result = validation.Validate(reviewModel);

            //assert
            Assert.True(result.IsValid);
        }

       
        [Fact]
        public void Description_Return_Null()
        {
            var reviewModel = new DetailsViewModel { Description = "" };
            validation.TestValidate(reviewModel).ShouldHaveValidationErrorFor(r => r.Description);
        }

        [Fact]
        public void Description_Return_Value()
        {
            var reviewModel = new DetailsViewModel { Description = "review description should have more than 20 words...." };
            validation.TestValidate(reviewModel).ShouldNotHaveValidationErrorFor(r => r.Description);
        }

    }
}
