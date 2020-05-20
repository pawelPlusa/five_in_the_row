using System;
using System.Text;
using System.Text.Unicode;

namespace FiveInTheRow
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game ourGame = new Game(5, 7);


            ourGame.Mark(ourGame.GetMove(), 1);
           

        }


    }
}
