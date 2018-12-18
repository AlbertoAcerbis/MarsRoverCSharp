using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Resources;

namespace MarsRover
{
    public static class InputValidator
    {
        private static Coordinates _PlateauDimensions;
        private static Coordinates _currentCoordinates;
        private static string _currentDirection;
        private static string _command;

        private static string[] _inputByLines;

        private const int ExpectedNumberOfInputLines = 3;
        private const int ExpectedLineWithPlateauDimension = 0;
        private const int ExpectedLineWithStartPosition = 1;
        private const int ExpectedLineWithCommand = 2;

        private const char LinesDelimeter = '\n';
        private const char ParametersDelimeter = ' ';

        private static readonly List<string> AllowedDirections = new List<string> { "N", "W", "E", "S" };

        public static NavigationParameters GetNaviagtionParametersFromInput(string input)
        {
            SplitInputByLines(input);
            SetPlateauDimensions(_inputByLines);
            SetStartPositionAndDirection(_inputByLines);
            SetCommand();

            return new NavigationParameters(_currentDirection, _PlateauDimensions, _currentCoordinates, _command);
        }

        private static void SplitInputByLines(string input)
        {
            var splitString = input.Split(LinesDelimeter);

            if (splitString.Length != ExpectedNumberOfInputLines)
            {
                throw new IncorrectInputFormatException();
            }

            _inputByLines = splitString;
        }

        private static void SetPlateauDimensions(string[] inputLines)
        {
            var stringPlateauDimensions = inputLines[ExpectedLineWithPlateauDimension].Split(ParametersDelimeter);

            if (PlateauDimensionsAreInvalid(stringPlateauDimensions))
            {
                throw new IncorrectPlateauDimensionsException();
            }

            _PlateauDimensions = new Coordinates
            {
                X = int.Parse(stringPlateauDimensions[0]),
                Y = int.Parse(stringPlateauDimensions[1])
            };
        }

        private static void SetStartPositionAndDirection(string[] inputByLines)
        {
            var stringCurrentPositionAndDirection = inputByLines[ExpectedLineWithStartPosition].Split(ParametersDelimeter);

            if (StartPositionIsInvalid(stringCurrentPositionAndDirection))
            {
                throw new IncorrectStartPositionException();
            }

            _currentCoordinates = new Coordinates
            {
                X = int.Parse(stringCurrentPositionAndDirection[0]),
                Y = int.Parse(stringCurrentPositionAndDirection[1])
            };

            _currentDirection = stringCurrentPositionAndDirection[2];
        }

        private static void SetCommand()
        {
            _command = _inputByLines[ExpectedLineWithCommand];
        }

        private static bool StartPositionIsInvalid(string[] stringCurrentPositionAndDirection)
        {
            if (stringCurrentPositionAndDirection.Length != 3 || !stringCurrentPositionAndDirection[0].All(char.IsDigit)
               || !stringCurrentPositionAndDirection[1].All(char.IsDigit) || !AllowedDirections.Any(stringCurrentPositionAndDirection[2].Contains))
            {
                return true;
            }

            if (int.Parse(stringCurrentPositionAndDirection[0]) > _PlateauDimensions.X ||
                int.Parse(stringCurrentPositionAndDirection[1]) > _PlateauDimensions.Y)
            {
                return true;
            }

            return false;
        }

        private static bool PlateauDimensionsAreInvalid(string[] stringPlateauDimensions)
        {
            if (stringPlateauDimensions.Length != 2 || !stringPlateauDimensions[0].All(char.IsDigit)
               || !stringPlateauDimensions[1].All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}