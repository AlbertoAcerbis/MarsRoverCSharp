using System;

namespace MarsRover.Resources
{
    public class IncorrectStartPositionException : Exception
    {
        public IncorrectStartPositionException()
        {
            throw new IncorrectStartPositionException(
                "Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)");
        }

        public IncorrectStartPositionException(string message) :
            base(message)
        { }
    }
}