using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    class Frame : ItemInBoard
    {
        public const int FRAME_HEIGHT = 50;
        public const int FRAME_WIDTH = 25;

        //members
        protected override char ItemChar { get; set; } = '.';
        protected override ConsoleColor ItemColor { get; set; } = ConsoleColor.Red;

        //ctor's
        public Frame(Board board) : base(board)
        {
            
        }
        //methods
        protected override void InitItem()
        {
            ItemCoords.Clear();
            for (int i = 0; i < FRAME_WIDTH; i++)
            {
                for (int j = 0; j < FRAME_HEIGHT; j++)
                {
                    if (i == 0 || j == 0 || i == FRAME_WIDTH - 1 || j == FRAME_HEIGHT - 1)
                        ItemCoords.Add(new Coordinate(i, j));
                }
            }
        }
    }
}
