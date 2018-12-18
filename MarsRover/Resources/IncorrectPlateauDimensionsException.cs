using System;

namespace MarsRover.Resources
{
    public class IncorrectPlateauDimensionsException : Exception
    {
        public IncorrectPlateauDimensionsException()
        {
            throw new IncorrectPlateauDimensionsException("Plateau dimensions should contain two int parameters: x and y");
        }

        public IncorrectPlateauDimensionsException(string message) :
            base(message)
        { }
    }
}