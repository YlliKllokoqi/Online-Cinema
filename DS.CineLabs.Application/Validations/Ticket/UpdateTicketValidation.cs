using DS.CineLabs.Common.Models.Ticket;
using FluentValidation;

namespace DS.CineLabs.Application.Validations.Ticket
{
    public class UpdateTicketValidation : AbstractValidator<UpdateTicketModel>
    {
        public UpdateTicketValidation()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0).WithMessage("ID cannot be empty");

            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be empty");

            RuleFor(x => x.MovieId).NotEmpty().NotNull().WithMessage("Movie ID cannot be empty");


        }
    }
}
