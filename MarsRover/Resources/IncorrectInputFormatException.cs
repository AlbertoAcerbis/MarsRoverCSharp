using System;

namespace MarsRover.Resources
{
    public class IncorrectInputFormatException : Exception
    {
        public IncorrectInputFormatException()
        {
            throw new IncorrectInputFormatException("Error occured while splitting the input: format is incorrect");
        }

        public IncorrectInputFormatException(string message) :
            base(message)
        {
        }
    }
}