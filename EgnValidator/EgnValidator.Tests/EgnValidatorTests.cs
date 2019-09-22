using System;
using Xunit;
using EgnValidator.App;

namespace EgnValidator.Tests
{
    public class EgnValidatorTests
    {
        [Theory]
        [InlineData("5010100000")]
        [InlineData("5010010000")]
        [InlineData("8402290000")]
        [InlineData("9011300000")]
        [InlineData("9512310000")]
        public void Correct_BirthDate_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn);

            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123456789")]
        [InlineData("12345678911")]
        public void Incorrect_Egn_Length_Or_Null_Should_Return_False(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("9550500000")]
        [InlineData("5050100000")]
        [InlineData("6010500000")]
        [InlineData("7011310000")]
        [InlineData("8502290000")]
        public void Incorrect_BirthDate_Should_Return_False(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
