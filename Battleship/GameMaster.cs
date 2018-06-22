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
            Setup();

            while(!playerOne.winsGame && !playerTwo.winsGame)
            {
                Turn();
            }
            

            Console.ReadLine();                     //Just here to pause the end game
        }


        public void FireOnBoard(Player humanPlayer, Player enemyPlayer)
        {
            char[] coordinates = new char[2];
            bool isHit;

            Console.WriteLine("{0}, where would you like to fire? Enter the X-coordinate followed by the Y-coordinate.", humanPlayer.name);
            coordinates = humanPlayer.GetCoordinates(humanPlayer.enemyBoard);
            isHit = HitOrMiss(coordinates, humanPlayer, enemyPlayer);

            if (isHit)
            {
                Console.WriteLine("\n\nYou hit a ship!\n\nPress Enter when you're ready to pass your turn.");
                humanPlayer.hitsLeftToWin--;
            }
            else
            {
                Console.WriteLine("\n\nYour shot missed!\n\nPress Enter when you're ready to pass your turn.");
            }
            Console.ReadLine();
        }

        public bool HitOrMiss(char[] coordinates, Player friendlyPlayer, Player enemyPlayer)
        {
            bool isHit;

            isHit = enemyPlayer.friendlyBoard.MarkHitOrMiss(coordinates);
            friendlyPlayer.enemyBoard.MarkHitOrMiss(coordinates, isHit);

            friendlyPlayer.enemyBoard.DisplayBoard();

            return isHit;
        }

        public void Turn()
        {
            playerOne.BeginPlayerTurn();
            FireOnBoard(playerOne, playerTwo);
            if(playerOne.hitsLeftToWin <= 0)
            {
                Console.WriteLine("{0} wins the game!!", playerOne.name);
                playerOne.winsGame = true;
                return;
            }

            playerTwo.BeginPlayerTurn();
            FireOnBoard(playerTwo, playerOne);
            if (playerTwo.hitsLeftToWin <= 0)
            {
                Console.WriteLine("{0} wins the game!!", playerTwo.name);
                playerTwo.winsGame = true;
                return;
            }
        }

        public void Setup()
        {
            playerOne.PlaceShips();
            playerOne.friendlyBoard.DisplayBoard();
            Console.ReadLine();
            Console.Clear();

            playerTwo.PlaceShips();
            playerTwo.friendlyBoard.DisplayBoard();
            Console.ReadLine();
            Console.Clear();
        }
    }
}
