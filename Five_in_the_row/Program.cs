using System;
using System.Text;
using System.Text.Unicode;

namespace FiveInTheRow
{
    class Program
    {
        static void Main(string[] args)
        {

            Game ourGame = new Game(5, 5);
            ourGame.GetMove();


            string input = Console.ReadLine();
            int number;
            int firsSign = input[1];
            Console.WriteLine(firsSign);
            int bar = int.Parse(firsSign.ToString());
            //bool checkIf = Int32.TryParse(input, out number);



            int height = 5;
            int width = 6;
            char A = 'A';
            int Aaa = (int)A;
            Console.WriteLine(Aaa);
            string test2 = "aaaaa";
                Console.WriteLine(test2.Length);

            int[,] ourBoard = CreateBoard(height, width);

            static int[,] CreateBoard(int height, int width)
            {
                int[,] board = new int[height, width];
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        board[x, y] = 0;
                    }
                }
                return board;
            }

            for (int x = 0; x < ourBoard.GetLength(0); x++)
            {
                for (int y = 0; y < ourBoard.GetLength(1); y++)
                {
                    //Console.WriteLine(initBoard[x,y]);
                    Console.Write(" {0} ", ourBoard[x, y]);
                }
                Console.WriteLine();
            }

        }


    }
}
