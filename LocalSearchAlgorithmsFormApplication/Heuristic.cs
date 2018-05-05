using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.Diagnostics; //for debugging

namespace LocalSearchAlgorithmsFormApplication
{
    class Heuristic
    {
        Queen[] queens = new Queen[10];
        int gridSize;
        public Heuristic(Queen[] queens, int gridSize)
        {
            this.queens = queens;
            this.gridSize = gridSize;

        }
        public int calculateHeuristic(Queen queen)
        {
            int h = 0;  //heuristic value 
            int sum = queen.getX() + queen.getY();  //sum value of coordinates
                                                    // int minus = Abs(queen.getX() - queen.getY()); //differance between coordinates

            for (int i = 0; i < gridSize; i++)
            {
                if (queens[i] != queen)
                {
                    if (queens[i].getX() == queen.getX() || queens[i].getY() == queen.getY()) // if they are in the same column or row
                    {
                        h++;
                    }
                    else if (queens[i].getX() + queens[i].getY() == sum)    //if their coordinate sums are equal (which means that they are alligned diagonally north-east or south-west way).
                    {
                        h++;
                    }
                    else if (queen.getX() - queen.getY() == queens[i].getX() - queens[i].getY())    //  this one makes sure they are alligned diagonally.
                    {
                        h++;
                    }

                }
            }

            return h;
        }
        public static int calculateHeuristicAllBoard(Queen[] board, int gridSize)
        {
            int h = 0;

            for (int j = 0; j < gridSize; j++)
            {

                // int h = 0;  //heuristic value 
                int sum = board[j].getX() + board[j].getY();  //sum value of coordinates
                                                              // int minus = Abs(queen.getX() - queen.getY()); //differance between coordinates

                for (int k = j; k < gridSize; k++)
                {
                    if (board[k] != board[j])
                    {
                        if (board[k].getX() == board[j].getX() || board[k].getY() == board[j].getY()) // if they are in the same column or row
                        {
                            h++;
                        }
                        else if (board[k].getX() + board[k].getY() == sum)    //if their coordinate sums are equal (which means that they are alligned diagonally north-east or south-west way).
                        {
                            h++;
                        }
                        else if (board[j].getX() - board[j].getY() == board[k].getX() - board[k].getY())    //  this one makes sure they are alligned diagonally.
                        {
                            h++;
                        }
                    }
                }
            }

            return h;
        }
        //// ************ DEBUG *****************************

        //    Debug.WriteLine("total heuristic: " + h);

        //// ************ DEBUG ******************************
    }

}
