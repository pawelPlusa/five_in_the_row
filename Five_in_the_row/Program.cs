using System;
using System.Text;
using System.Text.Unicode;

namespace FiveInTheRow
{
    class Program
    {
        static void Main(string[] args)
        {
           


            Game ourGame = new Game(7, 7);
            ourGame.board[0, 0] = 1;
            ourGame.board[1, 0] = 1;
            ourGame.board[1, 1] = 1;
            ourGame.board[1, 2] = 1;
            ourGame.board[1, 3] = 1;
            ourGame.board[1, 1] = 1;
            ourGame.board[3, 0] = 1;
            ourGame.board[3, 2] = 1;
            ourGame.board[3, 6] = 1;
            ourGame.board[4, 5] = 1;
            ourGame.board[5, 4] = 1;
            ourGame.board[6, 3] = 1;
            ourGame.DrawBoard(ourGame.board);
            Console.WriteLine(ourGame.IsWin(1, 4));

           

        }


    }
}
