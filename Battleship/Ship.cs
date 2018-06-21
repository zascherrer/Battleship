using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Ship
    {
        //variables
        public string name;
        public int size;

        //constructor
        public Ship()
        {
            name = "Tugboat";
            size = 1;
        }

        //methods
    }
}
