using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
//using System.Windows.Forms; //to be deleted...
using System.Diagnostics; //for debugging

namespace LocalSearchAlgorithmsFormApplication
{
    class HillClimb
    {
        const int maxNumberOfIterations = 10000;
        int gridSize;
        Queen[] queens = new Queen[10];
        public HillClimb(int gridSize, Queen[] queens)
        {
            this.gridSize = gridSize;
            this.queens = queens;
        }
        public Queen[] HillclimbingAlgorithm()
        {
            Heuristic heuristic = new Heuristic(queens, gridSize);
            Debug.WriteLine("");
            // ************ DEBUG *****************************
            for (int i = 0; i < gridSize; i++)
            {
                Debug.WriteLine(i + " queen " + " X - Y: " + queens[i].getX() + " - " + queens[i].getY() + " w/ heuristic: " + heuristic.calculateHeuristic(queens[i]));
            }
            // ************ DEBUG ******************************
            for (int x = 0; x < maxNumberOfIterations && Heuristic.calculateHeuristicAllBoard(queens, gridSize) != 0; x++)
            {

                for (int i = 0; i < gridSize; i++)  //for each queen
                {

                    List<int> equalList = new List<int>();
                    int h = heuristic.calculateHeuristic(queens[i]);

                    int rowInit = queens[i].getY();
                    equalList.Add(rowInit);
                    for (int j = 0; j < gridSize; j++)  //for each row
                    {
                        queens[i].setY(j);
                        int newH = heuristic.calculateHeuristic(queens[i]);
                        if (newH < h)
                        {
                            equalList.Clear();
                            h = newH;
                            equalList.Add(j);
                        }
                        else if (queens[i].getY() != rowInit && newH == h)
                        {
                            equalList.Add(j);
                        }
                    }
                    Random rand = new Random();
                    int row = rand.Next(0, equalList.Count);
                    queens[i].setY(equalList[row]);

                    // Debug.WriteLine(i + " queen " + " X - Y: " + queens[i].getX() + " - " + queens[i].getY() + " w/ heuristic: " + heuristic(queens[i]));
                    //MessageBox.Show("Queen " + i + " has " + h + " heuristics");
                    equalList.Clear();
                }

            }
            // *************** DEBUG *****************************
            Debug.WriteLine("");
            Debug.WriteLine("After HillClimb...");
            for (int i = 0; i < gridSize; i++)
            {
                Debug.WriteLine(i + " queen " + " X - Y: " + queens[i].getX() + " - " + queens[i].getY() + " w/ heuristic: " + heuristic.calculateHeuristic(queens[i]));
            }
            // *************** DEBUG ***************************
            //heuristic.calculateHeuristicAllBoard();
            return queens;
        }
    }
}
