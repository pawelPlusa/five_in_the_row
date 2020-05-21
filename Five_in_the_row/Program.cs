using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
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
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorSize = 100;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();




            
            do
            {
                try
                {
                    Console.WriteLine(Console.WindowWidth);
                    Console.WriteLine("Give number of board rows (max 26): ");
                    rows = Int32.Parse(Console.ReadLine());
                    if (rows > 26)
                    {
                        throw new InvalidDataException(); 
                    }
                    Console.WriteLine("Give number of board cols (max 99): ");
                    cols = Int32.Parse(Console.ReadLine());
                    if (cols > 99)
                    {
                        throw new InvalidProgramException();
                    }
                    Console.WriteLine("Give number of fields to get WIN: ");

                    howMany = Int32.Parse(Console.ReadLine());
                    if (howMany > rows || howMany > cols)
                    {
                        throw new ExecutionEngineException();
                    }
                    invalidInput = false;
                }
                catch(InvalidDataException)
                {
                    Console.WriteLine("Max 26 rows allowed");
                    invalidInput = true;
                }catch(InvalidProgramException)
                {
                    Console.WriteLine("Max 99 cols allowed");
                    invalidInput = true;
                }catch(ExecutionEngineException)
                {
                    Console.WriteLine("Could not be more than number of rows or cols");
                    invalidInput = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    invalidInput = true;
                }
            } while (invalidInput);


            var OurGame = new Game(rows, cols);
            //OurGame.board[0, 0] = 1;
            //OurGame.board[1, 1] = 1;
            //OurGame.board[2, 2] = 1;
            //OurGame.board[4, 4] = 1;
            //OurGame.board[5, 5] = 1;
            //OurGame.board[6, 6] = 1;
            //OurGame.board[4, 4] = 1;
            //OurGame.board[5, 4] = 1;
            int player = 1;
            bool isOver = true;

            while (isOver)
            {
                OurGame.Mark(OurGame.GetMove(player), player);
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
