using DS.CineLabs.Application.Validations.MovieDetails;
using DS.CineLabs.Common.Models.MovieDetails;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.MovieDetails
{
    public class CreateMovieDetailsValidationTest
    {
        private readonly CreateMovieDetailValidation validation;

        public CreateMovieDetailsValidationTest()
        {
            validation = new CreateMovieDetailValidation();
        }

        [Fact]
        public void MovieDetail_Return_Null()
        {
            //arrange
            var MovieDetailModel = new CreateMovieDetailsModel
            {
                Movie_Name = "",
                PhotoPathFile = null,
                Premiere = DateTime.MinValue,
                CoverFile = null,
                Director = "",
                Actors = "",
                Country = "",
                PG = "",
                Distributor = "",
                Length = 0,
                Schedule = "",
                Trailer = ""
            };

            //act
            var result = validation.Validate(MovieDetailModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void MovieDetail_return_value()
        {
            //arrange
            var MovieDetailModel = new CreateMovieDetailsModel
            {
                Movie_Name = "The Dark Knight",
                PhotoPathFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")),
                Premiere = DateTime.Now,
                CoverFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")),
                Director = "Christopher Nolan",
                Actors = "Christian Bale, Heath Ledger, Gary Oldman",
                Country = "USA",
                PG = "16+",
                Distributor = "Warner Bros",
                Length = 152,
                Schedule = "Friday 12 - 20:45",
                Trailer = "https://youtu.be/C5HFpTrT5ds"
            };

            //act
            var result = validation.Validate(MovieDetailModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void MovieDetail_MovieName_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Movie_Name = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Movie_Name);
        }

        [Fact]
        public void MovieDetail_MovieName_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Movie_Name = "Dark Knight" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Movie_Name);
        }



        [Fact]
        public void MovieDetail_PhotoPathFile_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { PhotoPathFile = null };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.PhotoPathFile);
        }

        [Fact]
        public void MovieDetail_PhotoPathFile_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { PhotoPathFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")) };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.PhotoPathFile);
        }

        [Fact]
        public void MovieDetail_CoverFile_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { CoverFile = null };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.CoverFile);
        }

        [Fact]
        public void MovieDetail_CoverFile_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { CoverFile = new FormFile(new MemoryStream(), 0, 2, null, Path.GetFileName("Foto")) };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.CoverFile);
        }

        [Fact]
        public void MovieDetail_Director_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Director = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Director);
        }

        [Fact]
        public void MovieDetail_Director_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Director = "Christopher Nolan" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Director);
        }

        [Fact]
        public void MovieDetail_Actors_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Actors = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Actors);
        }

        [Fact]
        public void MovieDetail_Actors_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Actors = "Christian Bale, Heath Ledger" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Actors);
        }

        [Fact]
        public void MovieDetail_Country_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Country = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Country);
        }

        [Fact]
        public void MovieDetail_Country_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Country = "USA" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Country);
        }

        [Fact]
        public void MovieDetail_PG_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { PG = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.PG);
        }

        [Fact]
        public void MovieDetail_PG_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { PG = "16+" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.PG);
        }

        [Fact]
        public void MovieDetail_Distributor_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Distributor = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Distributor);
        }

        [Fact]
        public void MovieDetail_Distributor_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Distributor = "Warner Bros" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Distributor);
        }

        [Fact]
        public void MovieDetail_Length_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Length = 0 };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Length);
        }

        [Fact]
        public void MovieDetail_Length_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Length = 152 };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Length);
        }

        [Fact]
        public void MovieDetail_Schedule_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Schedule = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Schedule);
        }

        [Fact]
        public void MovieDetail_Schedule_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Schedule = "Friday - 20:45" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Schedule);
        }

        [Fact]
        public void MovieDetail_Trailer_isEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Trailer = "" };
            validation.TestValidate(MovieDetailmodel).ShouldHaveValidationErrorFor(md => md.Trailer);
        }

        [Fact]
        public void MovieDetail_Trailer_IsNotEmpty()
        {
            var MovieDetailmodel = new CreateMovieDetailsModel { Trailer = "Friday - 20:45" };
            validation.TestValidate(MovieDetailmodel).ShouldNotHaveValidationErrorFor(md => md.Trailer);
        }
    }
}
