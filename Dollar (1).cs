using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    class Dollar : ItemInBoard
    {
        //members
        protected override char ItemChar { get; set; } = '$';
        protected override ConsoleColor ItemColor { get; set; } = ConsoleColor.Green;

        //ctor's
        public Dollar(Board board) : base(board)
        {

        }

        //methods
        protected override void InitItem()
        {
            ItemCoords.Clear();
            Coordinate coord = null;
            bool found = false;
            while (!found)
            {
                Random r = new Random();
                coord = new Coordinate(r.Next(1, Frame.FRAME_WIDTH - 1), r.Next(1, Frame.FRAME_HEIGHT - 1));
                if (Board.CoordInBoardStatus(coord) == CoordStatus.VALID && !(coord.X == 1 && coord.Y == 1)
                    && !(coord.X == Frame.FRAME_HEIGHT - 1 && coord.Y == Frame.FRAME_WIDTH - 1)
                    && !(coord.X == Frame.FRAME_HEIGHT - 1 && coord.Y == 1)
                    && !(coord.X == 1 && coord.Y == Frame.FRAME_WIDTH - 1))//valid and not corners 
                    found = true;
            }
            ItemCoords.Add(coord);
        }
    }
}
