using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    static class Printer
    {
        //methods
        public static void PrintCoords(List<Coordinate> coords, char charToPrint, ConsoleColor color)
        {
            foreach (var item in coords)
            {
                PrintCoords(item, charToPrint, color);            
            }
        }

        public static void PrintCoords(Coordinate coord, char charToPrint, ConsoleColor color)
        {
            Console.SetCursorPosition(coord.Y, coord.X);
            Console.ForegroundColor = color;
            Console.Write(charToPrint);
        }

        public static void DeleteCoords(List<Coordinate> coords)
        {
            foreach (var item in coords)
            {
                DeleteCoords(item);            
            }
        }

        public static void DeleteCoords(Coordinate coord)
        {
            Console.SetCursorPosition(coord.Y, coord.X);
            Console.Write(' ');
        }
    }
}
