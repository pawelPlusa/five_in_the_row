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
            //Dodać wyłącznosć wprowadzania liczb całkowitych
            Console.WriteLine("Give number of board rows: ");
            int rows = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Give number of board cols: ");
            int cols = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Give number of fields to get WIN: ");
            int howMany = Int32.Parse(Console.ReadLine());

            var OurGame = new Game(rows, cols);

            int player = 1;
            bool isOver = true;

            while (isOver)
            {
                OurGame.Mark(OurGame.GetMove(), player);
                if(OurGame.IsWin(player, howMany))
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
                    if (player == 1)
                    {
                        player = 2;
                    }
                    else
                    {
                        player = 1;
                    }
                }
            }


        }
    }
}
