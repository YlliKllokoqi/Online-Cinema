using DS.CineLabs.Application.Validations.Movie;
using DS.CineLabs.Common.Models.Movies;
using FluentValidation.TestHelper;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Movie
{
    public class UpdateMovieValidationTest
    {
        private readonly UpdateMovieValidation validation;
        public UpdateMovieValidationTest()
        {
            validation = new UpdateMovieValidation();
        }

        [Fact]
        public void Movie_Return_Null()
        {
            //arrange
            var movieModel = new UpdateMovieModel
            {
                Id = new System.Guid(),
                Name = "",
                Description = "",
                DetailsId = 0
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
            var movieModel = new UpdateMovieModel
            {
                Id = System.Guid.NewGuid(),
                Name = "updated name",
                Description = "updated description",
                DetailsId = 1
            };

            //act
            var result = validation.Validate(movieModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Name_Return_Null()
        {
            var movieModel = new UpdateMovieModel { Name = "" };
            validation.TestValidate(movieModel).ShouldHaveValidationErrorFor(m => m.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var movieModel = new UpdateMovieModel { Name = "movie name" };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.Name);
        }

        [Fact]
        public void Description_Return_Null()
        {
            var movieModel = new UpdateMovieModel { Description = "" };
            validation.TestValidate(movieModel).ShouldHaveValidationErrorFor(m => m.Description);
        }

        [Fact]
        public void Description_Return_Value()
        {
            var movieModel = new UpdateMovieModel { Description = "movie name" };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.Description);
        }

        [Fact]
        public void DetailsId_Greater_Than_Zero()
        {
            var movieModel = new UpdateMovieModel { DetailsId = 2 };
            validation.TestValidate(movieModel).ShouldNotHaveValidationErrorFor(m => m.DetailsId);
        }
    }
}
