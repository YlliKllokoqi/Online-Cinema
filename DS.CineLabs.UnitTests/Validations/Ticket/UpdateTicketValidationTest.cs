using DS.CineLabs.Application.Validations.Ticket;
using DS.CineLabs.Common.Models.Ticket;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Ticket
{
    public class UpdateTicketValidationTest
    {
        private readonly UpdateTicketValidation validation;

        public UpdateTicketValidationTest()
        {
            validation = new UpdateTicketValidation();
        }

        [Fact]
        public void Ticket_Return_Null()
        {
            //arrange
            var ticketModel = new UpdateTicketModel
            {
                Name = "",
                MovieId = new Guid()
            };

            //act
            var result = validation.Validate(ticketModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Ticket_Return_Value()
        {
            //arrange
            var ticketModel = new UpdateTicketModel
            {
                Id= 1,
                Name = "ticket",
                MovieId = Guid.NewGuid()
            };

            //act
            var result = validation.Validate(ticketModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Name_Return_Null()
        {
            var ticketModel = new UpdateTicketModel { Name = "" };
            validation.TestValidate(ticketModel).ShouldHaveValidationErrorFor(e => e.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var ticketModel = new UpdateTicketModel { Name = "ticket" };
            validation.TestValidate(ticketModel).ShouldNotHaveValidationErrorFor(e => e.Name);
        }

        [Fact]
        public void Id_Greater_Than_Zero()
        {
            var ticketModel = new UpdateTicketModel { Id = 1 };
            validation.TestValidate(ticketModel).ShouldNotHaveValidationErrorFor(e => e.Id);
        }

        [Fact]
        public void Id_Return_Value()
        {
            var ticketmodel = new UpdateTicketModel { Id = 1 };
            validation.TestValidate(ticketmodel).ShouldNotHaveValidationErrorFor(e => e.Id);
        }

        [Fact]
        public void Id_Return_Null()
        {
            var ticketmodel = new UpdateTicketModel { Id = 0 };
            validation.TestValidate(ticketmodel).ShouldHaveValidationErrorFor(e => e.Id);
        }

        [Fact]
        public void MovieId_Return_Value()
        {
            var ticketmodel = new UpdateTicketModel { MovieId = Guid.NewGuid() };
            validation.TestValidate(ticketmodel).ShouldNotHaveValidationErrorFor(e => e.MovieId);
        }

        [Fact]
        public void MovieId_Return_Null()
        {
            var ticketmodel = new UpdateTicketModel { MovieId = new Guid() };
            validation.TestValidate(ticketmodel).ShouldHaveValidationErrorFor(e => e.MovieId);
        }


        

   




    }
}
