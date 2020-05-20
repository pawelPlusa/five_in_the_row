using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInTheRow
{
    class Game
    {
        private int height;
        private int width;
        private int[,] board;

        public Game(int height, int width)
        {
            //this.height = height;
            //this.width = width;
            this.board = CreateBoard(height, width);
        }

        private int[,] CreateBoard(int height, int width)
        {
            int[,] board = new int[height, width];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    board[x, y] = 0;
                }
            }
            return board;
        }

        public (int, int) GetMove()
        {
            bool isCorrect = false;
            string input;
            do
            {
                input = Console.ReadLine();
                Console.WriteLine("please provide field");



                Console.WriteLine("input len" + input.Length);




                if (input.Length != 2 && input.Length != 3)
                {
                    Console.WriteLine("only 2 or 3 signs allowed");
                    continue;
                }

                int firstSign = input[0];
                int secondSign = input[1];
                Console.WriteLine(firstSign) ;
                Console.WriteLine(this.board.Length) ;
                if (!(firstSign < 65 || firstSign > this.board.Length))
                {
                    Console.WriteLine("use letters which corresponds with board rows");
                    continue;
                }
                if (input.Length == 3)
                {
                    string numericValue = input.Substring(1);
                    int finalNumericValue;
                    if (!(Int32.TryParse(numericValue, out finalNumericValue)))
                    {
                        Console.WriteLine("only numbers are allowed for second coordinate");
                        continue;
                    }
                }
                else
                {
                    if (!(secondSign >= 48 && secondSign <= 57))
                    {
                        Console.WriteLine("only numbers as second parameter");
                        continue;
                    }
                }
                isCorrect = true;
            }
            while (!isCorrect);
           
            Console.WriteLine("our input "+ input);
            int coordX = input[0] - 65;
            int coordY = int.Parse(input.Substring(1));
            return (coordX, coordY) ; 
           
            
        }


    }
}
