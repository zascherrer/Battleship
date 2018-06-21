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
        public List<Ship> ships;
        public string name;
        
        //constructor
        public Player()
        {
            name = "Default_Name";

            playerBoards = new GameBoard[2];
            playerBoards[0] = new FriendlyBoard();
            playerBoards[1] = new EnemyBoard();

            ships = new List<Ship>() { new Destroyer(), new Submarine(), new Battleship(), new Carrier()};
        }

        //methods
        public void PlaceShips()
        {
            string shipChosen;

            while(ships.Count > 0)
            {
                DisplayShipsRemaining();
                shipChosen = ChooseShip();
                RemoveShipFromShips(shipChosen);
            }


        }

        public void DisplayShipsRemaining()
        {
            Console.WriteLine("You have these ships left to place:\n");

            foreach (Ship ship in ships)
            {
                Console.WriteLine(ship.name);
            }
        }

        public string ChooseShip()
        {
            Console.WriteLine("\nWhich ship would you like to place?");
            string shipChosen = Console.ReadLine().ToLower();
            if (ValidateShipChoice(shipChosen))
            {
                return shipChosen;
            }
            else
            {
                Console.WriteLine("\n\nPlease enter the name of one of the remaining ships.\n\n");
                shipChosen = ChooseShip();
            }
            return shipChosen;
        }

        public bool ValidateShipChoice(string shipChosen)
        {
            for(int i = 0; i < ships.Count; i++)
            {
                if(shipChosen == ships[i].name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveShipFromShips(string shipChosen)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (shipChosen == ships[i].name.ToLower())
                {
                    ships.Remove(ships[i]);
                }
            }
        }

    }
}
