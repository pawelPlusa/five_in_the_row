using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInTheRow
{
    class Game
    {
        private int cols;
        private int rows;
        private int[,] board;

        public Game(int rows, int cols)
        {
            this.cols = cols;
            this.rows = rows;
            this.board = CreateBoard(rows , cols);
        }

        private int[,] CreateBoard(int rows, int  cols)
        {
            int[,] board = new int[rows , cols];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    board[x, y] = 0;
                }
            }
            this.DrawBoard(board);
            return board;
        }

        public (int, int) GetMove()
        {
            bool isCorrect = false;
            string input;
            int coordY;
            int coordX;
            do
            {
                Console.WriteLine("please provide coordinates for your move?");
                input = Console.ReadLine();
                
                if (input.Length != 2 && input.Length != 3)
                {
                    Console.WriteLine("only 2 or 3 signs allowed");
                    continue;
                }

                int firstSign = char.ToUpper(input[0]);
                int secondSign = input[1];
                if (!(firstSign < 65 || firstSign > this.board.Length/rows))
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
                coordY = char.ToUpper(input[0]) - 65;
                coordX = int.Parse(input.Substring(1));
                if (this.board[coordY, coordX] != 0)
                {
                    Console.WriteLine("this field was already taken");
                    continue;
                }
                isCorrect = true;
            }
            while (!isCorrect);
            coordY = char.ToUpper(input[0]) - 65;
            coordX = int.Parse(input.Substring(1));

            return (coordY, coordX) ; 
        }

        public void Mark((int,int)Coords, int player)
        {
            int rowCoord = Coords.Item1;
            int columnCoord = Coords.Item2;
            
            this.board[rowCoord, columnCoord] = player;
            DrawBoard(this.board);

        }

        public void DrawBoard(int[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    //Console.WriteLine(initBoard[x,y]);
                    Console.Write("{0}", board[x, y]);
                }
                Console.WriteLine();
            }
        }

        public bool IsWin(int player, int howMany)
        {
            bool hasWon = false;
            hasWon = horizontalCheck(player, howMany, 0, 0, 0);
            //We stopped here
            return hasWon;
        }

        public bool horizontalCheck(int player, int howMany, int row, int col, int counter)
        {   
            for(int x = row; x <= this.rows; x++)
            {
                for(int y = col; y <= this.cols; y++)
                {
                    if(this.board[x, y] == player)
                    {
                        counter++;
                        if( counter == howMany)
                        {
                            return true;
                        }
                        if(y == this.cols)
                        {
                            break;
                        }
                        y++;
                        return horizontalCheck(player, howMany, x, y, counter);
                    }
                }
            }
            return false;
            
        }
    }
}
