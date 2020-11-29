using System;
using System.Linq;

namespace MarsRover.Validation
{
    public class CommandValidation : IValidation
    {
        private readonly string input;

        public CommandValidation(string _input)
        {
            input = _input;
        }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(input))             
                throw new Exception("Command is null or empty");
             

            var inputValues = input.Split(" ");
            if (inputValues.Length != 1)            
                throw new Exception("Command length should be 1");
             

            char[] commands = { 'L', 'R', 'M' };
            if (!input.All(c => commands.Contains(c)))
            {
                throw new Exception("Invalid Movement!");
            }
        }
    }
}