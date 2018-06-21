using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class GameBoard
    {
        //variables
        public int sizeX;
        public int sizeY;
        public char background;
        public char hit;
        public char miss;
        char[,] board;

        //constructor
        public GameBoard()
        {
            sizeX = 20;
            sizeY = 20;
            background = '~';
            hit = 'X';
            miss = 'O';

            board = new char[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    board[i, j] = background;
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
    }
}
