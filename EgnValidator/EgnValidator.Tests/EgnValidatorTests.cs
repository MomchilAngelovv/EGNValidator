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
            var actualResult = egnValidator.Validate(inputEgn, null);

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
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("9550500000")]
        [InlineData("5050100000")]
        [InlineData("7011310000")]
        [InlineData("8502290000")]
        public void Incorrect_BirthDate_Should_Return_False(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8825050000")]
        [InlineData("8822290000")]
        [InlineData("8831300000")]
        [InlineData("8932310000")]
        [InlineData("8901310000")]
        public void Before_1900_With_MonthPlus20_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8899150000")]
        [InlineData("8843150000")]
        [InlineData("8820150000")]
        public void Before_1900_With_IncorrectData_MonthPlus20_Should_Return_False(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8802690000")]
        [InlineData("5631510000")]
        [InlineData("8831700000")]
        [InlineData("6010500000")]
        public void After_1900_With_DayPlus40_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8702690000")]
        [InlineData("5631720000")]
        [InlineData("8831400000")]
        public void After_1900_With_IncorrectData_DayPlus40_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn, null);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
