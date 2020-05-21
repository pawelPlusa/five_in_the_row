using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Unicode;

namespace FiveInTheRow
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.GameLogic();
        }
        public static void GameLogic()
        {
            int rows = 0;
            int cols = 0;
            int howMany = 0;
            bool invalidInput;
            do
            {
                try
                {
                    Console.WriteLine("Give number of board rows: ");
                    rows = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Give number of board cols: ");
                    cols = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Give number of fields to get WIN: ");
                    howMany = Int32.Parse(Console.ReadLine());
                    invalidInput = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    invalidInput = true;
                }
            } while (invalidInput);


            var OurGame = new Game(rows, cols);

            int player = 1;
            bool isOver = true;

            while (isOver)
            {
                OurGame.Mark(OurGame.GetMove(), player);
                if (OurGame.IsWin(player, howMany))
                {
                    OurGame.PrintResult(player);
                    isOver = false;
                }
                else if (OurGame.IsFull(OurGame.board))
                {
                    OurGame.PrintResult(0);
                    isOver = false;
                }
                else
                {
                    player = (player == 1 ? 2 : 1);
                }

            }
        }
    }
}
