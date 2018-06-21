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
        char[][] board;

        //constructor
        public GameBoard()
        {
            sizeX = 20;
            sizeY = 20;
            background = '~';
            hit = 'X';
            miss = 'O';
            
            for(int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    board[i][j] = background;
                }
            }
        }

        //methods
    }
}
