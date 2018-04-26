using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; //for debugging

namespace LocalSearchAlgorithmsFormApplication
{
    class SimulatedAnnealing
    {
        Queen[] queens = new Queen[10];
        int gridSize;
        int temperature;
        int coolingFactor;

        const int maxNumberOfIterations = 1000;

        public SimulatedAnnealing(int gridSize, Queen[] queens, int temprature, int coolingFactor)
        {
            this.queens = queens;
            this.gridSize = gridSize;
            this.temperature = temprature;
            this.coolingFactor = coolingFactor;
        }

        public Queen[] simulatedAnnealingAlgorithm()
        {
            int temp = temperature;
            Heuristic heuristic = new Heuristic(queens, gridSize);

            // ************ DEBUG *****************************
            for (int i = 0; i < gridSize; i++)
            {
                Debug.WriteLine(i + " queen " + " X - Y: " + queens[i].getX() + " - " + queens[i].getY() + " w/ heuristic: " + heuristic.calculateHeuristic(queens[i]));
            }
            // ************ DEBUG ******************************
            for(int x= 0; x<maxNumberOfIterations && Heuristic.calculateHeuristicAllBoard(queens, gridSize) != 0; x++) {
                
                    
                for (int i = 0; i < gridSize; i++)   //for each queen
                {
                    temperature = temp;
                    int h = heuristic.calculateHeuristic(queens[i]);
                    int rowInit = queens[i].getY();
                    while (temperature > 0)
                    {
                        Random rand = new Random();
                        int row = rand.Next(0, gridSize);
                        queens[i].setY(row);

                        int deltaH = heuristic.calculateHeuristic(queens[i]) - h;

                        if (deltaH < 0)
                        {
                            //queens[i].setY(rowInit);
                            h = heuristic.calculateHeuristic(queens[i]);
                            continue;
                        }

                        Random rand2 = new Random();
                        const int decimals = 10000;
                        int large = rand2.Next(0, decimals);
                        double threshold = (double)large / decimals; //gives a random value between 0,1 ??????????????????????????????????

                        double probability = Math.Exp(-(double)deltaH / (double)temperature);
                        if (probability < threshold)    //if the probability value is smaller than threshold
                        {
                            queens[i].setY(rowInit);    //the y value would be set back to original.
                        }
                        temperature -= coolingFactor;
                    }
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


            return queens;
        }
    }
}
