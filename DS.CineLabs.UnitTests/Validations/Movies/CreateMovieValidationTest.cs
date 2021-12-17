using DS.CineLabs.Application.Validations.Movie;
using DS.CineLabs.Common.Models.Movies;
using FluentValidation.TestHelper;
using System.Collections.Generic;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Movies
{
    public class CreateMovieValidationTest
    {
        private readonly CreateMovieValidation validation;
        public CreateMovieValidationTest()
        {
            validation = new CreateMovieValidation();
        }

        [Fact]
        public void Movie_Return_Null()
        {
            //arrange
            var movieModel = new MovieViewModel
            {
              Name = "",
              Description = "",
              DetailsId = 0,
              Id = new System.Guid(),
              selectedCategories = null   
            };

            //act
            var result = validation.Validate(movieModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Movie_Return_Value()
        {
            //arrange
            var movieModel = new MovieViewModel
            {
                Name = "The Dark knight",
                Description = "123",
                DetailsId = 1,
                Id = System.Guid.NewGuid(),
                selectedCategories = new List<int>(){1,2}
            };

            //act
            var result = validation.Validate(movieModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Name_Return_Null()
        {
            var movieModel = new MovieViewModel { Name = "" };
            validation.TestValidate(movieModel).ShouldHaveValidationErrorFor(m => m.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var movieModel = new MovieViewModel { Name = "movie name" };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.Name);
        }

        [Fact]
        public void Description_Return_Null()
        {
            var movieModel = new MovieViewModel { Description = "" };
            validation.TestValidate(movieModel).ShouldHaveValidationErrorFor(m => m.Description);
        }

        [Fact]
        public void Description_Return_Value()
        {
            var movieModel = new MovieViewModel { Description = "movie name" };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.Description);
        }

        [Fact]
        public void DetailsId_Greater_Than_Zero()
        {
            var movieModel = new MovieViewModel { DetailsId = 2 };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.DetailsId);
        }
    }
}
