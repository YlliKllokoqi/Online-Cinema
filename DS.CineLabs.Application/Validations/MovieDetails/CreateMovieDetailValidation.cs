using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Common.Models.MovieDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Validations.MovieDetails
{
    public class CreateMovieDetailValidation : AbstractValidator<CreateMovieDetailsModel>
    {

        public CreateMovieDetailValidation()
        {
            RuleFor(x => x.Movie_Name).NotEmpty();
            RuleFor(x => x.PhotoPathFile).NotEmpty();
            RuleFor(x => x.CoverFile).NotEmpty();
            RuleFor(x => x.Premiere).NotEmpty();
            RuleFor(x => x.Director).NotEmpty();
            RuleFor(x => x.Actors).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.PG).NotEmpty();
            RuleFor(x => x.Distributor).NotEmpty();
            RuleFor(x => x.Length).NotEmpty();
            RuleFor(x => x.Schedule).NotEmpty();
            RuleFor(x => x.Trailer).NotEmpty();
        }
    }
}
