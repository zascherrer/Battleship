using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class GameBoard
    {
        //variables
        public int sizeX;
        public int sizeY;
        public char background;
        public char hit;
        public char miss;
        public char ship;
        char[,] board;

        //constructor
        public GameBoard()
        {
            sizeX = 20;
            sizeY = 20;
            background = '~';
            hit = 'X';
            miss = 'O';
            ship = 'N';

            board = new char[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    board[j, i] = background;
                }
            }
        }

        //methods
        public void DisplayBoard()
        {
            string boardRow = "";

            Console.WriteLine("     A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T ");
            for (int i = 0; i < sizeX; i++)
            {
                boardRow += "   " + ConvertIntToChar(i + 1);
                for (int j = 0; j < sizeY; j++)
                {
                    boardRow += " " + board[i,j] + " ";
                }
                Console.WriteLine(boardRow);
                boardRow = "";
            }
        }

        public char ConvertIntToChar(int number)
        {
            switch (number)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
                case 6:
                    return 'F';
                case 7:
                    return 'G';
                case 8:
                    return 'H';
                case 9:
                    return 'I';
                case 10:
                    return 'J';
                case 11:
                    return 'K';
                case 12:
                    return 'L';
                case 13:
                    return 'M';
                case 14:
                    return 'N';
                case 15:
                    return 'O';
                case 16:
                    return 'P';
                case 17:
                    return 'Q';
                case 18:
                    return 'R';
                case 19:
                    return 'S';
                case 20:
                    return 'T';
                default:
                    return 'A';
            }
        }

        public int[] ConvertCoordinatesToIndex(char[] coordinates)
        {
            int[] index = new int[2];
            index[0] = ConvertCharToInt(coordinates[1]);
            index[1] = ConvertCharToInt(coordinates[0]);

            return index;
        }

        public int ConvertCharToInt(char character)
        {
            switch (character)
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case 'i':
                    return 8;
                case 'j':
                    return 9;
                case 'k':
                    return 10;
                case 'l':
                    return 11;
                case 'm':
                    return 12;
                case 'n':
                    return 13;
                case 'o':
                    return 14;
                case 'p':
                    return 15;
                case 'q':
                    return 16;
                case 'r':
                    return 17;
                case 's':
                    return 18;
                case 't':
                    return 19;
                default:
                    return 0;
            }
        }

        public bool FindIfShipFits(char[] coordinatesChar, string direction, int shipSize)
        {
            int[] coordinates = new int[2];
            coordinates = ConvertCoordinatesToIndex(coordinatesChar);

            switch (direction)
            {
                case "up":
                    if (coordinates[0] - (shipSize - 1) >= 0)
                    {
                        if(CheckForShipInWay(coordinates, direction, shipSize))
                        {
                            return false;
                        }
                        for (int i = 0; i < shipSize; i++)
                        {
                            board[coordinates[0] - i, coordinates[1]] = ship;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "down":
                    if (coordinates[0] + (shipSize - 1) < sizeY)
                    {
                        if (CheckForShipInWay(coordinates, direction, shipSize))
                        {
                            return false;
                        }
                        for (int i = 0; i < shipSize; i++)
                        {
                            board[coordinates[0] + i, coordinates[1]] = ship;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "left":
                    if (coordinates[1] - (shipSize - 1) >= 0)
                    {
                        if (CheckForShipInWay(coordinates, direction, shipSize))
                        {
                            return false;
                        }
                        for (int i = 0; i < shipSize; i++)
                        {
                            board[coordinates[0], coordinates[1] - i] = ship;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "right":
                    if (coordinates[1] + (shipSize - 1) < sizeX)
                    {
                        if (CheckForShipInWay(coordinates, direction, shipSize))
                        {
                            return false;
                        }
                        for (int i = 0; i < shipSize; i++)
                        {
                            board[coordinates[0], coordinates[1] + i] = ship;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    Console.WriteLine("\n\nDirection was invalid.\n\n");
                    return false;
            }
        }

        public bool CheckForShipInWay(int[] coordinates, string direction, int shipSize)
        {
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (board[coordinates[0] - i, coordinates[1]] == ship)
                        {
                            Console.WriteLine("There's another ship in the way!");
                            return true;
                        }
                    }
                    return false;
                case "down":
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (board[coordinates[0] + i, coordinates[1]] == ship)
                        {
                            Console.WriteLine("There's another ship in the way!");
                            return true;
                        }
                    }
                    return false;
                case "left":
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (board[coordinates[0], coordinates[1] - i] == ship)
                        {
                            Console.WriteLine("There's another ship in the way!");
                            return true;
                        }
                    }
                    return false;
                case "right":
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (board[coordinates[0], coordinates[1] + i] == ship)
                        {
                            Console.WriteLine("There's another ship in the way!");
                            return true;
                        }
                    }
                    return false;
                default:
                    return true;
            }
        }

        public bool MarkHitOrMiss(char[] coordinatesChar, bool isHit = false)
        {
            int[] coordinates = new int[2];
            coordinates = ConvertCoordinatesToIndex(coordinatesChar);

            if (isHit)
            {
                board[coordinates[0], coordinates[1]] = hit;
                return true;
            }
            else
            {
                if(board[coordinates[0], coordinates[1]] == ship)
                {
                    board[coordinates[0], coordinates[1]] = hit;
                    return true;
                }
                else if(board[coordinates[0], coordinates[1]] == hit || board[coordinates[0], coordinates[1]] == miss)
                {
                    Console.WriteLine("\n\nYou already shot there!\n\n");
                    return false;
                }
                else
                {
                    board[coordinates[0], coordinates[1]] = miss;
                    return false;
                }
            }
        }
    }
}
