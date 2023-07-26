using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    class Coordinate
    {
        //members
        public int X { get; set; }
        public int Y { get; set; }

        //ctor's
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        //methods
        public void MoveCoordByDirection(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.LeftArrow:
                    { Y--; }
                    break;
                case ConsoleKey.UpArrow:
                    { X--; }
                    break;
                case ConsoleKey.RightArrow:
                    { Y++; }
                    break;
                case ConsoleKey.DownArrow:
                    { X++; }
                    break;
            }
        }
        public override string ToString()
        {
            return this.X + " " + this.Y;
        }

        public override bool Equals(object obj)
        {
            Coordinate c = null;
            if (obj is Coordinate)
            {
                c = (Coordinate)obj;
                return (this.X == c.X && this.Y == c.Y);
            }
            return false;
        }
    }
}
