using System;
using System.Linq;

namespace MarsRover.Validation
{
    public class PositionValidation : IValidation
    {
        private readonly string input;
        private readonly int width;
        private readonly int height;

        public PositionValidation(string _input, int _width, int _height)
        {
            input = _input;
            width = _width;
            height = _height;
        }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Position is null or empty");

            var inputValues = input.Split(" ");
            if (inputValues.Length != 3)
                throw new Exception("Position length should be 3");

            for (int i = 0; i < 2; i++)
            {
                var isParseable = int.TryParse(inputValues[i], out int number);
                if (isParseable == false)               
                    throw new Exception("Invalid Position!");                 
            }

            if (int.Parse(inputValues[0]) > width || int.Parse(inputValues[0]) < 0)            
                throw new Exception("Starting position must be inside the plateau!");
           

            if (int.Parse(inputValues[1]) > height || int.Parse(inputValues[1]) < 0)            
                throw new Exception("Starting position must be inside the plateau!");
             

            string[] directions = { "N", "E", "S", "W" };
            if (!directions.Contains(inputValues[2]))
                throw new Exception("Invalid Directions!");
 
        }
    }
}