using MarsRover.Resources;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverInoutTest
    {
        [Theory]
        [InlineData("5 5\n0 0 N\nM", 5, 5, 0, 0, "N", "M")]
        [InlineData("10 10\n5 9 E\nLMLMLM", 10, 10, 5, 9, "E", "LMLMLM")]
        public void Can_Parse_AnInputCorrectly(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var expectedPlateausDimensions = new Coordinates { X = expectedXPlateauDimension, Y = expectedYPlateauDimension };
            var expectedStartingPosition = new Coordinates { X = expectedXStartPosition, Y = expectedYStartPosition };

            var expectedNavigationParameters = new NavigationParameters(expectedDirection, expectedPlateausDimensions,
                expectedStartingPosition, expectedCommand);

            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            var actualResult = marsRover.NavigationParameters;

            Assert.Equal(actualResult, expectedNavigationParameters);
        }

        [Theory]
        [InlineData("10 10 5\n1 9 E\nLMLMLM")]
        [InlineData("10\n5 9 E\nLMLMLM")]
        [InlineData("10 A\n5 9 E\nLMLMLM")]
        public void Return_Exception_When_WrongPlateauDimensionsInput(string input)
        {
            var marsRover = new MarsRover(input);

            var ex = Assert.Throws<IncorrectPlateauDimensionsException>(() =>
                marsRover.Initialize());

            Assert.Equal("Plateau dimensions should contain two int parameters: x and y", ex.Message);
        }

        [Theory]
        [InlineData("1 1\n1 1\nLMLMLM")]
        [InlineData("1 1\n1 N\nLMLMLM")]
        [InlineData("1 1\n1\nLMLMLM")]
        [InlineData("5 5\n5 A N\nLMLMLM")]
        [InlineData("5 5\n5 1 A\nLMLMLM")]
        [InlineData("1 1\n5 1 N\nLMLMLM")]
        public void Return_Exception_When_WrongStartPositionInput(string input)
        {
            var marsRover = new MarsRover(input);

            var ex = Assert.Throws<IncorrectStartPositionException>(() =>
                marsRover.Initialize());

            Assert.Equal("Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)", ex.Message);
        }

        [Theory]
        [InlineData("10 10; 5 9; LMLMLM")]
        [InlineData("10 10\nLMLMLM")]
        public void Return_Exception_When_WrongInputFormat(string input)
        {
            var marsRover = new MarsRover(input);

            var ex = Assert.Throws<IncorrectInputFormatException>(() =>
                marsRover.Initialize());

            Assert.Equal("Error occured while splitting the input: format is incorrect", ex.Message);
        }
    }
}