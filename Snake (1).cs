using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    class Snake : ItemInBoard
    {
        private const int SNAKE_BASE_LENGTH = 5;
        protected override char ItemChar { get; set; } = (char)1;
        protected override ConsoleColor ItemColor { get; set; } = ConsoleColor.DarkRed;

        private Coordinate snakeHeadCoords;
        public Coordinate SnakeHeadCoords//good but not understood..
        {
            get
            {
                return snakeHeadCoords;
            }
            set
            {
                snakeHeadCoords = new Coordinate(value.X, value.Y);
            }

        }

        public Snake(Board board) : base(board)
        {
            //board.printboard(); 
        }

        protected override void InitItem()
        {
            ItemCoords.Clear();
            for (int i = 1; i <= SNAKE_BASE_LENGTH; i++)
            {
                ItemCoords.Add(new Coordinate(1, i));//init the snake coords
            }
            SnakeHeadCoords = ItemCoords[ItemCoords.Count - 1];//update the head coord
        }

        public void MoveSnake(Coordinate newCoord)
        {
            //if the move is valid           
            DeleteItemFromScreen(ItemCoords[0]);//??
            ItemCoords.RemoveAt(0);
            //?refresh d
            Grow(newCoord);
        }

        public void Grow(Coordinate newCoord)
        {
            PrintItemOnScreen(ItemCoords[ItemCoords.Count - 1]);
            ItemCoords.Add(newCoord);
            SnakeHeadCoords = ItemCoords[ItemCoords.Count - 1];//=new coord
        }
    }
}
