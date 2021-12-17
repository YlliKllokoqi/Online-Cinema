using DS.CineLabs.Application.Dtos.Category;
using DS.CineLabs.Common.Models.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Validations.Category
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Name of category can not be empty");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id can not be lower than 1");
        }
    }
}
