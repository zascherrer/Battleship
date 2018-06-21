using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class EnemyBoard : GameBoard
    {
        //variables
        public char destroyedShip;

        //constructor
        public EnemyBoard()
        {
            destroyedShip = 'D';
        }

        //methods
    }
}
