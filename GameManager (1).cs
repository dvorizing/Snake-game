using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Snake__
{
    class GameManager
    {
        //members
        private readonly int MAX_NUM_OF_TRYINGS = 3;
        private readonly ConsoleKey DEFAULT_DIRECTION = ConsoleKey.RightArrow;
        private readonly int TIME_TO_SLEEP = 200;//speed

        private Board board;

        private ConsoleKey currentDirection;
        private int currentTrying;
        private Coordinate currentCoord;
        //ctor's
        public GameManager()
        {
            Console.WriteLine("enter level 1-4");
            int speed = int.Parse(Console.ReadLine());
            TIME_TO_SLEEP = (5 - speed) * 65;
            board = new Board();
            currentDirection = DEFAULT_DIRECTION;//at first
            currentTrying = 0;
            Console.ForegroundColor = ConsoleColor.Red;//not so nice..
            Console.SetCursorPosition(Frame.FRAME_HEIGHT, Frame.FRAME_WIDTH);
            Console.WriteLine($"you have more: {MAX_NUM_OF_TRYINGS - currentTrying} tryings");

        }
        //methods
        private void HandleUserMistake()//each step we check if invalid
        {
            if (board.CoordInBoardStatus(currentCoord) == CoordStatus.INVALID)
            {
                currentTrying++;
                Console.SetCursorPosition(Frame.FRAME_HEIGHT, Frame.FRAME_WIDTH);
                Console.WriteLine($"you have more: {MAX_NUM_OF_TRYINGS - currentTrying} tryings");
                board.RefreshBoard();
                currentCoord = board.SnakeHeadCoord();
                currentDirection = DEFAULT_DIRECTION;
                
            }

        }

        private void HandleUserMove(bool isToSleep)//didn't use the bool
        {
            while (!Console.KeyAvailable)//while no new key input
            {
                if (currentTrying == MAX_NUM_OF_TRYINGS)
                {
                    Console.SetCursorPosition(Frame.FRAME_HEIGHT + 1, Frame.FRAME_WIDTH + 1);
                    Console.WriteLine("Game-over:(");
                    return;
                }
                currentCoord = board.SnakeHeadCoord();
                currentCoord.MoveCoordByDirection(currentDirection);//get the new coord
                HandleUserMistake();//if valid what we want to do- to go to the new coord
                board.HandleMoveOnBoard(currentCoord);//now it will be in according to the new (or what stayed from before)
                                                      //coordinate
                Sleep();//move only each 1000ms
            }
            //new key input
            currentDirection = Console.ReadKey().Key;
            HandleUserMove(true);

        }

        private void Sleep()
        {

            Thread.Sleep(TIME_TO_SLEEP);

        }

        public void StartGame()
        {
            this.board.PrintBoard();
            HandleUserMove(true);
        }
    }
}
