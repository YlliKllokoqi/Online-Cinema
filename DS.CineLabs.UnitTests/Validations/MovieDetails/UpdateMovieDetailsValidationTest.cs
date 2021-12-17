using DS.CineLabs.Application.Validations.MovieDetails;
using DS.CineLabs.Common.Models.MovieDetails;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.MovieDetails
{
    public class UpdateMovieDetailsValidationTest
    {
        private readonly UpdateMovieDetailValidation validation;

        public UpdateMovieDetailsValidationTest()
        {
            validation = new UpdateMovieDetailValidation();
        }

        [Fact]
        public void MovieDetail_return_null()
        {
            //arrange
            var MovieDetailModel = new UpdateMovieDetailsModel
            {
                Movie_Name = "",
                PhotoPath = "",
                Premiere = DateTime.MinValue,
                Director = "",
                Actors = "",
                Country = "",
                PG = "",
                Distributor = "",
                Length = 0,
                Schedule = ""
            };

            //act
            var result = validation.Validate(MovieDetailModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void MovieDetail_return_value()
        {
            var MovieDetailModel = new UpdateMovieDetailsModel
            {
                Id = 1,
                Movie_Name = "The Dark Knight",
                PhotoPath = "PhotoPath",
                Premiere = DateTime.Now,
                Director = "Christopher Nolan",
                Actors = "Christian Bale, Heath Ledger, Gary Oldman",
                Country = "USA",
                PG = "16+",
                Distributor = "Warner Bros",
                Length = 152,
                Schedule = "Friday 12 - 20:45"
            };

            //act
            var result = validation.Validate(MovieDetailModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void MovieDetail_Id_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Id = 0 };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Id);
        }

        [Fact]
        public void MovieDetail_Id_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Id = 1 };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Id);
        }

        [Fact]
        public void MovieDetail_MovieName_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Movie_Name = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Movie_Name);
        }

        [Fact]
        public void MovieDetail_MovieName_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Movie_Name = "random.jpg" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Movie_Name);
        }

        [Fact]
        public void MovieDetail_PhotoPath_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { PhotoPath = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.PhotoPath);
        }

        [Fact]
        public void MovieDetail_PhotoPath_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { PhotoPath = "random.jpg" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.PhotoPath);
        }

        [Fact]
        public void MovieDetail_Director_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Director = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Director);
        }

        [Fact]
        public void MovieDetail_Director_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Director = "Christopher Nolan" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Director);
        }

        [Fact]
        public void MovieDetail_Actors_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Actors = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Actors);
        }

        [Fact]
        public void MovieDetail_Actors_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Actors = "Christian Bale, Heath Ledger" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Actors);
        }

        [Fact]
        public void MovieDetail_Country_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Country = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Country);
        }

        [Fact]
        public void MovieDetail_Country_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Country = "USA" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Country);
        }

        [Fact]
        public void MovieDetail_PG_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { PG = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.PG);
        }

        [Fact]
        public void MovieDetail_PG_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { PG = "16+" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.PG);
        }

        [Fact]
        public void MovieDetail_Distributor_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Distributor = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Distributor);
        }

        [Fact]
        public void MovieDetail_Distributor_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Distributor = "Warner Bros" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Distributor);
        }

        [Fact]
        public void MovieDetail_Length_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Length = 0 };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Length);
        }

        [Fact]
        public void MovieDetail_Length_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Length = 152 };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Length);
        }

        [Fact]
        public void MovieDetail_Schedule_isEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Schedule = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Schedule);
        }

        [Fact]
        public void MovieDetail_Schedule_IsNotEmpty()
        {
            var MovieDetailmodel = new UpdateMovieDetailsModel { Schedule = "Friday - 20:45" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Schedule);
        }
    }
}
