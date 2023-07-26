using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    abstract class ItemPrintable
    {
        //members
        protected virtual char ItemChar { get; set; }
        protected virtual ConsoleColor ItemColor { get; set; } 
        protected virtual List<Coordinate> ItemCoords { get; set; } = new List<Coordinate>();

        //methods
        public void PrintItemOnScreen()
        {
            Printer.PrintCoords(ItemCoords, ItemChar, ItemColor);
        }

        protected void PrintItemOnScreen(Coordinate coord)
        {
            Printer.PrintCoords(coord, ItemChar, ItemColor);
        }

        protected void DeleteItemFromScreen()
        {
            Printer.DeleteCoords(ItemCoords);
        }

        protected void DeleteItemFromScreen(Coordinate coord)
        {
            Printer.DeleteCoords(coord);
        }
    }
}
