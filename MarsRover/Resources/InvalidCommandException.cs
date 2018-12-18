using System;

namespace MarsRover.Resources
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
            throw new InvalidCommandException("Command is invalid: Rover is sent outside the Plateau");
        }

        public InvalidCommandException(string message)
            : base(message)
        {

        }
    }
}