namespace MarsRover
{
    public class MarsRover
    {
        private readonly string _input;
        private MarsRoverNavigator _marsRoverNavigator;

        public MarsRover(string input)
        {
            this._input = input;
        }

        public NavigationParameters NavigationParameters { get; private set; }
        public string FinalPosition { get; private set; }

        public void Initialize()
        {
            this.NavigationParameters = InputValidator.GetNaviagtionParametersFromInput(this._input);
        }

        public void Navigate()
        {
            this._marsRoverNavigator = new MarsRoverNavigator(this.NavigationParameters);
            this.FinalPosition = this._marsRoverNavigator.Navigate();
        }
    }
}