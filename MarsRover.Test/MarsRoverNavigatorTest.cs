using MarsRover.Resources;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverNavigatorTest
    {
        [Theory]
        [InlineData("5 5\n0 0 N\nL", "0 0 W")]
        [InlineData("5 5\n0 0 N\nR", "0 0 E")]
        [InlineData("5 5\n0 0 W\nL", "0 0 S")]
        [InlineData("5 5\n0 0 W\nR", "0 0 N")]
        [InlineData("5 5\n0 0 S\nL", "0 0 E")]
        [InlineData("5 5\n0 0 S\nR", "0 0 W")]
        [InlineData("5 5\n0 0 E\nL", "0 0 N")]
        [InlineData("5 5\n0 0 E\nR", "0 0 S")]
        [InlineData("5 5\n1 1 N\nM", "1 2 N")]
        [InlineData("5 5\n1 1 W\nM", "0 1 W")]
        [InlineData("5 5\n1 1 S\nM", "1 0 S")]
        [InlineData("5 5\n1 1 E\nM", "2 1 E")]
        public void Can_UpdateDirection_When_PassSpinDirections(string input, string expectedDirection)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            marsRover.Navigate();

            var actualResult = marsRover.FinalPosition;

            Assert.Equal(actualResult, expectedDirection);
        }

        [Theory]
        [InlineData("5 5\n0 0 N\nM", "0 1 N")]
        [InlineData("5 5\n1 1 N\nMLMR", "0 2 N")]
        [InlineData("5 5\n1 1 W\nMLMLMLM", "1 1 N")]
        [InlineData("5 5\n0 0 N\nMMMMM", "0 5 N")]
        [InlineData("5 5\n0 0 E\nMMMMM", "5 0 E")]
        [InlineData("5 5\n0 0 N\nRMLMRMLMRMLMRMLM", "4 4 N")]
        public void Can_UpdatePosition_When_PassCorrectInput(string input, string expectedPosition)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            marsRover.Navigate();

            var actualResult = marsRover.FinalPosition;

            Assert.Equal(actualResult, expectedPosition);
        }

        [Theory]
        [InlineData("1 1\n0 0 N\nMM")]
        [InlineData("1 1\n0 0 E\nMM")]
        public void Can_Return_Exception_When_Command_Sends_RoverOutOfPlateau(string input)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();

            var ex = Assert.Throws<InvalidCommandException>(() =>
                marsRover.Navigate());

            Assert.Equal("Command is invalid: Rover is sent outside the Plateau", ex.Message);
        }
    }
}
