namespace MarsRover
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; }
        public Coordinates PlateauDimensions { get; }
        public Coordinates CurrentCoordinates { get; private set; }

        public NavigationParameters(string currentDirection, Coordinates PlateauDimensions, Coordinates currentCoordinates, string command)
        {
            this.CurrentDirection = currentDirection;
            this.PlateauDimensions = PlateauDimensions;
            this.CurrentCoordinates = currentCoordinates;
            this.Command = command;
        }

        public void UpdateCurrentDirection(string newDirection)
        {
            this.CurrentDirection = newDirection;
        }

        internal void UpdateCurrentCoordinates(Coordinates newCoordinates)
        {
            this.CurrentCoordinates = newCoordinates;
        }
    }
}