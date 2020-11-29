using System;

namespace MarsRover.Validation
{
    public class CoordinateValidation : IValidation
    {
        private readonly string input;

        public CoordinateValidation(string _input)
        {
            input = _input;
        }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Coordinate is null or empty");

            var inputValues = input.Split(" ");

            if (inputValues.Length != 2)
                throw new Exception("Coordinate length should be 2");

            foreach (string value in inputValues)
            {
                var isParseable = int.TryParse(value, out int number);
                if (isParseable == false)
                    throw new Exception("Invalid Coordinate!");

                if (number <= 0)
                    throw new Exception("Coordinate must be greater than zero!");

            }

        }
    }
}