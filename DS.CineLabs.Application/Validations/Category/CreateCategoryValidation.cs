using DS.CineLabs.Common.Models.Category;
using FluentValidation;

namespace DS.CineLabs.Application.Validations.Category
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidation()
        {
            
            RuleFor(X => X.Name).NotEmpty().WithMessage("Name of category can not be empty");
        }
    }
}
