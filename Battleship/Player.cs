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
        public GameBoard friendlyBoard;
        public GameBoard enemyBoard;
        public List<Ship> ships;
        public string name;
        public bool winsGame;
        public int hitsLeftToWin;
        
        //constructor
        public Player()
        {
            name = "Default_Name";
            winsGame = false;
            hitsLeftToWin = 9;

            friendlyBoard = new GameBoard();
            enemyBoard = new GameBoard();

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
                PlaceShipOnBoard(shipChosen);
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

        public void PlaceShipOnBoard(string shipChosen)
        {
            char[] coordinates = new char[2];
            int[] coordinatesInt = new int[2];
            string chosenDirection;
            bool isValidSpot = false;
            bool isValidDirection = false;

            while (!isValidSpot)
            {
                Console.WriteLine("\n\nWhere would you like to place the ship? Type the X-coordinate followed by the Y-coordinate of where you want to place one end of the ship.\n\n");
                coordinates = GetCoordinates(friendlyBoard);
                coordinatesInt = friendlyBoard.ConvertCoordinatesToIndex(coordinates);

                if(friendlyBoard.board[coordinatesInt[0], coordinatesInt[1]] != friendlyBoard.ship)
                {
                    isValidSpot = true;
                }
                else
                {
                    Console.WriteLine("You've already placed a ship there!");
                }
            }

            while (!isValidDirection)
            {
                Console.WriteLine("\n\nWould you like to place the ship facing up, down, left or right?");
                chosenDirection = Console.ReadLine().ToLower();
                if (ValidateDirection(chosenDirection))
                {
                    if (friendlyBoard.FindIfShipFits(coordinates, chosenDirection, ConvertStringToShip(shipChosen).size))
                    {
                        isValidDirection = true;
                    }
                    else
                    {
                        Console.WriteLine("\n\nThe ship doesn't fit there!\n\n");
                    }
                }
            }
        }

        public char[] GetCoordinates(GameBoard board)
        {
            char[] coordinates = new char[2];

            board.DisplayBoard();
            coordinates[0] = Console.ReadLine().ToLower()[0];
            coordinates[1] = Console.ReadLine().ToLower()[0];

            return coordinates;
        }

        public bool ValidateDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return true;
                case "down":
                    return true;
                case "left":
                    return true;
                case "right":
                    return true;
                default:
                    return false;
            }
        }

        public Ship ConvertStringToShip(string whatToConvert)
        {
            switch (whatToConvert)
            {
                case "destroyer":
                    return new Destroyer();
                case "submarine":
                    return new Submarine();
                case "battleship":
                    return new Battleship();
                case "aircraft carrier":
                    return new Carrier();
                default:
                    return new Destroyer();
            }
        }

        public void BeginPlayerTurn()
        {
            Console.Clear();
            Console.WriteLine("It's {0}'s turn! Press Enter when you're ready to display your boards:", name);
            Console.ReadLine();

            Console.WriteLine("\n\nEnemy Board:");
            enemyBoard.DisplayBoard();
            Console.WriteLine("\n\nFriendly Board:");
            friendlyBoard.DisplayBoard();
        }
    }
}
