using MarsRover.Resources;

namespace MarsRover
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters _navigationParameters;
        private readonly SpinningControl _spinningControl;
        private readonly MovingControl _movingControl;

        public MarsRoverNavigator(NavigationParameters navigationParameters)
        {
            this._navigationParameters = navigationParameters;
            this._spinningControl = new SpinningControl();
            this._movingControl = new MovingControl();
        }

        public string Navigate()
        {
            var command = this._navigationParameters.Command;

            foreach (var step in command)
            {
                DoAStep(step);
            }

            var result = $"{this._navigationParameters.CurrentCoordinates.X} {this._navigationParameters.CurrentCoordinates.Y} {this._navigationParameters.CurrentDirection}";

            return result;
        }

        private void DoAStep(char stepCommand)
        {
            var newDirection = this._spinningControl.GetNextDirection(this._navigationParameters.CurrentDirection, stepCommand);

            this._navigationParameters.UpdateCurrentDirection(newDirection);

            var newCoordinates = this._movingControl.Move(stepCommand, this._navigationParameters.CurrentDirection, this._navigationParameters.CurrentCoordinates);

            if (newCoordinates.X > this._navigationParameters.PlateauDimensions.X || newCoordinates.Y > this._navigationParameters.PlateauDimensions.Y)
            {
                throw new InvalidCommandException();
            }

            this._navigationParameters.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}