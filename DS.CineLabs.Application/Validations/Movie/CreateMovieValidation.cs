using DS.CineLabs.Common.Models.Movies;
using FluentValidation;

namespace DS.CineLabs.Application.Validations.Movie
{
    public class CreateMovieValidation : AbstractValidator<MovieViewModel>
    {
        public CreateMovieValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description can not be empty");
            RuleFor(x => x.DetailsId).NotNull().NotEmpty();
            //RuleFor(x => x.selectedCategories).NotEmpty();
        }
    }
}
