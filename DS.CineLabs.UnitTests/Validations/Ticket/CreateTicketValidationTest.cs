using DS.CineLabs.Application.Validations.Ticket;
using DS.CineLabs.Common.Models.Ticket;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Ticket
{
    public class CreateTicketValidationTest
    {
        private readonly CreateTicketValidation validation;

        public CreateTicketValidationTest()
        {
            validation = new CreateTicketValidation();
        }

        [Fact]
        public void Ticket_Return_Null()
        {
            //arrange
            var ticketModel = new CreateTicketModel
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
            var ticketModel = new CreateTicketModel
            {
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
            var ticketModel = new CreateTicketModel { Name = "" };
            validation.TestValidate(ticketModel).ShouldHaveValidationErrorFor(e => e.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var ticketModel = new CreateTicketModel { Name = "ticket" };
            validation.TestValidate(ticketModel).ShouldNotHaveValidationErrorFor(e => e.Name);
        }

        [Fact]
        public void MovieId_Return_Value()
        {
            var ticketmodel = new CreateTicketModel { MovieId = System.Guid.NewGuid() };
            validation.TestValidate(ticketmodel).ShouldNotHaveValidationErrorFor(e => e.MovieId);
        }

        [Fact]
        public void MovieId_Return_Null()
        {
            var ticketmodel = new CreateTicketModel { MovieId = new System.Guid() };
            validation.TestValidate(ticketmodel).ShouldHaveValidationErrorFor(e => e.MovieId);
        }


  

        


    }
}
