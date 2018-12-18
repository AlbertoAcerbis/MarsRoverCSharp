using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class SpinningControl
    {
        private static readonly LinkedList<string> Directions =
            new LinkedList<string>(new[] { "N", "W", "S", "E" });

        public readonly Dictionary<char, Func<string, string>> SpinningFunctions =
            new Dictionary<char, Func<string, string>>
            {
                {'L', TurnLeft},
                {'R', TurnRight},
                {'M', Stay }
            };

        public string GetNextDirection(string currentDirection, char stepCommand)
        {
            return SpinningFunctions[stepCommand](currentDirection);
        }

        private static string TurnRight(string currentDirection)
        {
            var currentIndex = Directions.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft(string currentDirection)
        {
            var currentIndex = Directions.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }

        private static string Stay(string currentDirection)
        {
            return currentDirection;
        }
    }
}