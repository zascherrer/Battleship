using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class GameMaster
    {
        //variables
        Player playerOne;
        Player playerTwo;

        //constructor
        public GameMaster(bool playerTwoIsHuman)
        {
            Console.WriteLine("\n\nPlayer one,");
            playerOne = new Human();
            if (playerTwoIsHuman)
            {
                Console.WriteLine("\n\nPlayer two,");
                playerTwo = new Human();
            }
            else
            {
                //playerTwo = new Computer();
            }

        }

        //methods
        public void RunGame()
        {
            playerOne.PlaceShips();
            playerOne.friendlyBoard[0].DisplayBoard();

            Console.ReadLine();                     //Just here to pause the end game
        }
    }
}
