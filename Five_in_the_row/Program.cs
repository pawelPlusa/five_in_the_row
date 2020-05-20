using System;
using System.Text;
using System.Text.Unicode;

namespace FiveInTheRow
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game ourGame = new Game(10, 10);
            ourGame.board[0, 0] = 1;
            ourGame.board[0, 1] = 1;
            ourGame.board[3, 0] = 1;
            ourGame.board[3, 1] = 1;
            ourGame.board[3, 2] = 1;
            Console.WriteLine(ourGame.IsWin(1, 5));

           

        }


    }
}
