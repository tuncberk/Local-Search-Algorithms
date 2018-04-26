using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalSearchAlgorithmsFormApplication
{
    class Queen
    {
        //public Queen[] queens = new Queen[10];
        private int x;
        private int y;
        //private int heuristicValue;

        public Queen()
        {

        }
        public Queen(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int X)
        {
            x = X;
        }
        public void setY(int Y)
        {
            y = Y;
        }
        //public int getHeuristic()
        //{
        //    return heuristicValue;
        //}
    }
}
