using DS.CineLabs.Application.Dtos.Ticket;
using DS.CineLabs.Common.Models.Ticket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Validations.Ticket
{
    public class CreateTicketValidation : AbstractValidator<CreateTicketModel>
    {
        public CreateTicketValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be empty");

            RuleFor(x => x.MovieId).NotEmpty().NotNull().WithMessage("Movie ID cannot be empty");

             
    }
    }
}
