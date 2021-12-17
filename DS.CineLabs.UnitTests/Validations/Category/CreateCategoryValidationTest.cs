using DS.CineLabs.Application.Validations.Category;
using DS.CineLabs.Common.Models.Category;
using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DS.CineLabs.UnitTests.Validations.Category
{
   public class CreateCategoryValidationTest
    {
        private readonly CreateCategoryValidation validation;

        public CreateCategoryValidationTest()
        {
            validation = new CreateCategoryValidation();
        }

        [Fact]
        public void Category_Return_Null()
        {
            //arrange
            var categoryModel = new CreateCategoryModel
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
            var categoryModel = new CreateCategoryModel
            {
                Name = "event"
            };

            //act
            var result = validation.Validate(categoryModel);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Name_Return_Null()
        {
            var categoryModel = new CreateCategoryModel { Name = "" };
            validation.TestValidate(categoryModel).ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Fact]
        public void Name_Return_Value()
        {
            var categoryModel = new CreateCategoryModel { Name = "event" };
            validation.TestValidate(categoryModel).ShouldNotHaveValidationErrorFor(c => c.Name);
        }

    
    }
}
