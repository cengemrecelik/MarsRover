using MarsRover.Enums;
using System;

namespace MarsRover
{
    public class Rover
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public Direction Direction { get; set; }

        public Rover(int pointX, int pointY, Direction direction)
        {
            PointX = pointX;
            PointY = pointY;
            Direction = direction;
        }

        private void Left()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private void Right()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private void Move(int Width, int Height)
        {
            switch (Direction)
            {
                case Direction.N:
                    if (PointY + 1 <= Height)
                        PointY++;
                    else
                        throw new Exception("The rover cannot out of the plateau!");
                    break;
                case Direction.E:
                    if (PointX + 1 <= Width)
                        PointX++;
                    else
                        throw new Exception("The rover cannot out of the plateau!");
                    break;
                case Direction.S:
                    if (PointY - 1 >= 0)
                        PointY--;
                    else
                        throw new Exception("The rover cannot out of the plateau!");
                    break;
                case Direction.W:
                    if (PointX - 1 >= 0)
                        PointX--;
                    else
                        throw new Exception("The rover cannot out of the plateau!");
                    break;
            }
        }

        public void Execute(string command, Plateau plateau)
        {
            foreach (var c in command)
            {
                switch (c)
                {
                    case 'L':
                        Left();
                        break;
                    case 'R':
                        Right();
                        break;
                    case 'M':
                        Move(plateau.Width, plateau.Height);
                        break;
                }
            }
        }
    }
}