using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInTheRow
{
    class Game
    {
        private int cols;
        private int rows;
        public int[,] board;

        public Game(int rows, int cols)
        {
            this.cols = cols;
            this.rows = rows;
            this.board = CreateBoard(rows, cols);
        }

        private int[,] CreateBoard(int rows, int cols)
        {
            int[,] board = new int[rows, cols];
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

        public (int, int) GetMove(int player)
        {
            bool isCorrect = false;
            string input;
            int coordY;
            int coordX;
            do
            {
                Console.WriteLine("Player: {0}, please provide coordinates for your move or type 'quit' to leave the game: ", player);
                input = Console.ReadLine();
                if (input == "quit")
                {
                    Environment.Exit(0);
                }
                if (input.Length != 2 && input.Length != 3)
                {
                    Console.WriteLine("only 2 or 3 signs allowed");
                    continue;
                }

                int firstSign = char.ToUpper(input[0]);
                int secondSign = input[1];
                if (!(firstSign < 65 || firstSign > this.board.Length / rows))
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

            return (coordY, coordX);
        }

        public void Mark((int, int) Coords, int player)
        {
            int rowCoord = Coords.Item1;
            int columnCoord = Coords.Item2;

            this.board[rowCoord, columnCoord] = player;
            DrawBoard(this.board);

        }

        public void DrawBoard(int[,] board)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - ((cols/2)-1)) / 2, Console.CursorTop);
            Console.Write("  ");
            for (int colNum = 0; colNum < this.cols; colNum++)
            {
                Console.Write("{0} ", colNum);
            }
            Console.WriteLine();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                char colLetter = (char)(x + 65);
                Console.SetCursorPosition((Console.WindowWidth - ((cols / 2) - 1)) / 2, Console.CursorTop);
                Console.Write("{0} ", colLetter);
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if(board[x, y] == 0)
                    {
                        
                        Console.Write("{0} ", (char)46); // It s ASCII symbol for empty field
                        
                    }
                    else if(board[x, y] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", (char)(966)); // It s ASCII symbol for player 1
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", (char)(991)); // It s ASCII symbol for player 2
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                }
                Console.WriteLine();
            }
        }

        public bool IsWin(int player, int howMany)
        {
            if (
           HorizontalCheck(player, howMany, 0, 0, 0, this.board) ||
           VerticalCheck(player, howMany, 0, 0, 0, this.board) ||
           DiagonalRightCheck(player, howMany, 0, 0, 0,this.board) || 
           DiagonalLeftCheck(player, howMany, 0, this.cols, 0, this.board))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HorizontalCheck(int player, int howMany, int row, int col, int counter, int[,] board, bool lastMatched = false)
        {
            int[,] boardTemp = board.Clone() as int[,];

            for (int x = row; x <= this.rows - 1; x++)
            {
                //by funkcja wiedziala czy jest rekurencja i ma przyjac jej parametry czy pozwolic na reset
                for (int y = (lastMatched ? col : 0); y <= this.cols - 1; y++)
                {
                    if (boardTemp[x, y] == player)
                    {
                        counter++;
                        boardTemp[x, y] = 0;
                        lastMatched = true;
                        if (counter == howMany)
                        {
                            return true;
                        }
                        //zabezpiecza przed wysypaniem gdy testowalismy dla y przy scianie
                        if (y < cols - 1)
                        {
                            y++;
                        }
                        else
                        {
                            lastMatched = false;
                            x = 0;
                            counter = 0;
                            break;

                        }
                        
                        return HorizontalCheck(player, howMany, x, y, counter, boardTemp, lastMatched);

                    }
                    else if (y > 0 && boardTemp[x, y] == 0 && this.board[x, y - 1] == 1 && lastMatched)
                    {
                        x = 0;
                        counter = 0;
                        lastMatched = false;
                        break;
                    }


                }
            }
            return false;

        }
        public bool VerticalCheck(int player, int howMany, int row, int col, int counter, int[,] board, bool lastMatched = false)
        {
            int[,] boardTemp = board.Clone() as int[,];
            for (int y = col; y <= this.cols - 1; y++)
            {
                for (int x = lastMatched ? row : 0 ; x <= this.rows - 1; x++)
                {

                    if (boardTemp[x, y] == player)
                    {
                        counter++;
                        boardTemp[x, y] = 0;
                        lastMatched = true;
                        if (counter == howMany)
                        {
                            return true;
                        }
                        //zabezpiecza przed wysypaniem gdy testowalismy dla y przy scianie
                        if (x < rows - 1)
                        {
                            x++;
                        }
                        else
                        {
                            lastMatched = false;
                            y = 0;
                            counter = 0;
                            break;

                        }

                        return VerticalCheck(player, howMany, x, y, counter, boardTemp, lastMatched);
                    }
                    else if (x > 0 && boardTemp[x, y] == 0 && this.board[x -1, y] == 1 && lastMatched)
                    {
                        x = 0;
                        counter = 0;
                        lastMatched = false;
                        break;
                    }
                }
            }
            return false;
        }
        public bool DiagonalRightCheck(int player, int howMany, int row, int col, int counter, int[,] board, bool lastMatched = false)
        {
            int[,] boardTemp = board.Clone() as int[,];

            for (int x = lastMatched ? row : 0; x <= this.rows - 1; x++)
            {
                for (int y = lastMatched ? col : 0 ; y <= this.cols - 1; y++)
                {
                    if (boardTemp[x, y] == player)
                    {
                        counter++;
                        boardTemp[x, y] = 0;
                        lastMatched = true;
                        if (counter == howMany)
                        {
                            return true;
                        }

                        // else zabezpiecza przed sytuacją gdy y = 0 i tym samym chce zmienic y na cos poza indexem
                        if (y < cols -1 && x < rows -1)
                        {
                            y++;
                            x++;
                        }
                        else
                        {
                            lastMatched = false;
                            x = 0;
                            counter = 0;
                            break;
                        }
                        return DiagonalRightCheck(player, howMany, x, y, counter, boardTemp, lastMatched);
                    }
                    else if (y > 0 && x > 0 && boardTemp[x, y] == 0 && this.board[x - 1, y - 1] == 1 && lastMatched)
                    {
                        x = 0;
                        counter = 0;
                        lastMatched = false;
                        break;
                        //return DiagonalRightCheck(player, howMany, x, y, counter, boardTemp, lastMatched);
                    }
                }

            
            }
            return false;

        }
        public bool DiagonalLeftCheck(int player, int howMany, int row, int col, int counter, int[,] board, bool lastMatched = false)
        {
            int[,] boardTemp = board.Clone() as int[,];
            for (int x = row; x <= this.rows - 1; x++)
            {
                //by funkcja wiedziala czy jest rekurencja i ma przyjac jej parametry czy pozwolic na reset
                for (int y = lastMatched ? col : (cols - 1); y >= 0; y--)
                {
                    if (boardTemp[x, y] == player)
                    {
                        counter++;
                        boardTemp[x, y] = 0;
                        lastMatched = true;
                        if (counter == howMany)
                        {
                            return true;
                        }

                        // else zabezpiecza przed sytuacją gdy y = 0 i tym samym chce zmienic y na cos poza indexem
                        if (y > 0)
                        {
                            y--;
                            x++;
                        } else
                        {
                            lastMatched = false;
                            x = 0;
                            counter = 0;
                            break;
                        }
                        
                        //Console.WriteLine("x to pass: " + x + "y to pass: " + y + "last match: " + lastMatched);
                        return DiagonalLeftCheck(player, howMany, x, y, counter, boardTemp, lastMatched);
                    }
                    else if (y < (cols-1) && x > 0 && boardTemp[x, y] == 0 && this.board[x - 1, y + 1] == 1 && lastMatched)
                    {
                        x = 0;
                        counter = 0;
                        lastMatched = false;
                        break;
                    }
                }
            }
            return false;
        }


        public bool IsFull(int[,] board)
        {
            foreach(int field in board)
            {
                if(field == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void PrintResult(int player)
        {
            if(player == 1)
            {
                Console.WriteLine("X won!");
            }
            else if (player == 2)
            {
                Console.WriteLine("O won!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }

        }

    }
}

