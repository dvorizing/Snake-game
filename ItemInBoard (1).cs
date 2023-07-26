using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    abstract class ItemInBoard : ItemPrintable
    {
        //mambers
        protected virtual Board Board { get; set; }

        //ctor's
        protected ItemInBoard(Board board)
        {
            Board = board;
            InitItem();
        }

        //methods

        protected abstract void InitItem();

        public void RefreshItem()
        {
            DeleteItemFromScreen();
            InitItem();
            PrintItemOnScreen();
        }

        public bool IsItemInCoord(Coordinate coord)
        {
            foreach (var item in ItemCoords)
            {
                if (item.Equals(coord))
                    return true;
            }
            return false;
        }
    }
}
