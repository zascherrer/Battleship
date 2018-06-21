using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Player
    {
        //variables
        public GameBoard[] playerBoards;
        public string name;
        
        //constructor
        public Player()
        {
            name = "Default_Name";
            playerBoards = new GameBoard[2];
            playerBoards[0] = new FriendlyBoard();
            playerBoards[1] = new EnemyBoard();
        }

        //methods
    }
}
