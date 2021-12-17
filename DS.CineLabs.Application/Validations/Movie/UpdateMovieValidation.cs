using DS.CineLabs.Common.Models.Movies;
using FluentValidation;

namespace DS.CineLabs.Application.Validations.Movie
{
    public class UpdateMovieValidation : AbstractValidator<UpdateMovieModel>
    {
        public UpdateMovieValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.DetailsId).NotNull().NotEmpty();
        }
    }
}
