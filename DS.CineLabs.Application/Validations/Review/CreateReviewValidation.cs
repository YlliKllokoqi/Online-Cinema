using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Common.Models.Home;
using DS.CineLabs.Common.Models.Review;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Validations.Review
{
   public class CreateReviewValidation : AbstractValidator<DetailsViewModel>
    {
        public CreateReviewValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
