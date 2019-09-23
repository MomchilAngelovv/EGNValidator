namespace EgnValidator.Tests
{
    using System.Collections.Generic;

    using Xunit;

    using EgnValidator.App;
    using EgnValidator.App.Models;

    public class EgnValidatorTests
    {
        private readonly IList<Person> peopleLog = new List<Person>();

        [Theory]
        [InlineData("5010100006")]
        [InlineData("5010010005")]
        [InlineData("8402290000")]
        [InlineData("9011300006")]
        [InlineData("9512310007")]
        public void Correct_BirthDate_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

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
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

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
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8825050002")]
        [InlineData("8822290000")]
        [InlineData("8831300008")]
        [InlineData("8932310004")]
        [InlineData("8901310008")]
        public void Before_1900_With_MonthPlus20_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

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
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("8802690001")]
        [InlineData("5631510001")]
        [InlineData("8831700004")]
        [InlineData("6010500004")]
        public void After_1900_With_DayPlus40_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

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
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("6101057509")]
        [InlineData("9001014406")]
        [InlineData("9001014427")]
        [InlineData("9001014643")]
        public void Correct_Checksum_Should_Return_True(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = true;
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("6101057507")]
        [InlineData("6101057508")]
        [InlineData("6101057500")]
        public void Incorrect_Checksum_Should_Return_False(string inputEgn)
        {
            var egnValidator = new Validator();

            var expectedResult = false;
            var actualResult = egnValidator.Validate(inputEgn, null, peopleLog);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
