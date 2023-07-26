using System;
using System.Collections.Generic;
using System.Text;

namespace Snake__
{
    enum CoordStatus { VALID, DOLLAR_TOUCHED, INVALID }
    class Board
    {
        public static int dollars = 0;///------no updating after failing

        //members
        private Snake snake;
        private Dollar dollar;
        private Frame frame;

        private List<ItemInBoard> itemsInBoard = new List<ItemInBoard>();

        //ctor's 
        public Board()
        {
            snake = new Snake(this);
            dollar = new Dollar(this);
            frame = new Frame(this);
            itemsInBoard.Add(snake);
            itemsInBoard.Add(dollar);
            itemsInBoard.Add(frame);
            //RefreshBoard();
        }

        //methods
        public void RefreshBoard()
        {
            foreach (var item in itemsInBoard)
            {
                item.RefreshItem();
            }

            //snake = new snake(this)...

        }
        public void PrintBoard()
        {
            foreach (var item in itemsInBoard)
            {
                item.PrintItemOnScreen();
            }
        }

        public CoordStatus CoordInBoardStatus(Coordinate coord)
        {
            if ((frame != null && frame.IsItemInCoord(coord)) || (snake != null && snake.IsItemInCoord(coord)))
                return CoordStatus.INVALID;
            if (dollar != null && dollar.IsItemInCoord(coord))
                return CoordStatus.DOLLAR_TOUCHED;
            return CoordStatus.VALID;
        }

        public void HandleMoveOnBoard(Coordinate currentCoord)
        {
            if (CoordInBoardStatus(currentCoord) == CoordStatus.VALID)//if it is a normal movement
            {
                snake.MoveSnake(currentCoord);
            }
            else
            /*if (CoordInBoardStatus(currentCoord) == CoordStatus.DOLLAR_TOUCHED)*///if it touched a dollar
            {
                Console.SetCursorPosition(Frame.FRAME_HEIGHT / 2, Frame.FRAME_WIDTH + 3);///------
                Console.WriteLine($"num of dollars by now: {++dollars}");///------
                snake.Grow(currentCoord);
                dollar.RefreshItem();
                //dollar.PrintItemOnScreen();
            }
        }
        public Coordinate SnakeHeadCoord()
        {
            return snake.SnakeHeadCoords;
        }
    }
}
