using DS.CineLabs.Application.Validations.Category;
using DS.CineLabs.Common.Models.Category;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Category
{
    public class UpdateCategoryValidationTest
    {
        private readonly UpdateCategoryValidation validation;

        public UpdateCategoryValidationTest()
        {
            validation = new UpdateCategoryValidation();
        }
        [Fact]
        public void Category_Return_Null()
        {
            //arrange
            var categoryModel = new UpdateCategoryModel
            {
                Name = ""
            };

            //act
            var result = validation.Validate(categoryModel);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Category_Return_Value()
        {
            //arrange
            var categoryModel = new UpdateCategoryModel
            {
                Id = 1,
                Name = "event"
            };

            //act
            var result = validation.Validate(categoryModel);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact]
        public void Id_Greater_Than_Zero()
        {
            var categoryModel = new UpdateCategoryModel { Id = 1 };
            validation.TestValidate(categoryModel).ShouldNotHaveValidationErrorFor(c => c.Id);
        }


        [Fact]
        public void Name_Return_Null()
        {
            var categoryModel = new UpdateCategoryModel { Name = "" };
            validation.TestValidate(categoryModel).ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var categoryModel = new UpdateCategoryModel { Name = "event" };
            validation.TestValidate(categoryModel).ShouldNotHaveValidationErrorFor(c => c.Name);
        }

 
    }
}
