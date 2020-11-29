using MarsRover.Enums;
using MarsRover.Validation;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Input:");
            var upperRight = "5 5";
            //rover1
            var position1 = "1 2 N";
            var command1 = "LMLMLMLMM";
            //rover2
            var position2 = "3 3 E";
            //   var command2 = "MMRMMRMRRM";
            var command2 = "LLLLMR";
            Console.WriteLine(upperRight + "\n" + position1 + "\n" + command1 + "\n" + position2 + "\n" + command2  );
             
            new CoordinateValidation(upperRight).IsValid();
            var upperRightValues = upperRight.Split(" ");
            var plateau = new Plateau
            {
                Width = int.Parse(upperRightValues[0]),
                Height = int.Parse(upperRightValues[1]),
                Rovers = new List<Rover>()
            };

            //rover1
            new PositionValidation(position1, plateau.Width, plateau.Height).IsValid();
            var positionValues1 = position1.Split(" ");
            var rover1 = new Rover(int.Parse(positionValues1[0]), int.Parse(positionValues1[1]), (Direction)Enum.Parse(typeof(Direction), positionValues1[2]));
            new CommandValidation(command1).IsValid();
            rover1.Execute(command1, plateau);
            plateau.Rovers.Add(rover1);

            //rover2
            new PositionValidation(position2, plateau.Width, plateau.Height).IsValid();
            var positionValues2 = position2.Split(" ");
            var rover2 = new Rover(int.Parse(positionValues2[0]), int.Parse(positionValues2[1]), (Direction)Enum.Parse(typeof(Direction), positionValues2[2]));
            new CommandValidation(command2).IsValid();
            rover2.Execute(command2, plateau);
            plateau.Rovers.Add(rover2);

            Console.WriteLine("Output:");
            foreach (var item in plateau.Rovers)
            {
                Console.WriteLine(item.PointX + " " + item.PointY + " " + item.Direction);
            }
        }
    }
}
