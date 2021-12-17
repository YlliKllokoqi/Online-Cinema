using DS.CineLabs.Common.Models.MovieCategories;
using FluentValidation;

namespace DS.CineLabs.Application.Validations.MovieCategories
{
    public class CreateMovieCategoriesValidation : AbstractValidator<CreateMovieCategoriesModel>
    {
        public CreateMovieCategoriesValidation()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
