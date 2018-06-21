using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Human : Player
    {
        //variables

        //constructor
        public Human()
        {
            Console.WriteLine("please enter your name: ");
            name = Console.ReadLine();
        }

        //methods
    }
}
