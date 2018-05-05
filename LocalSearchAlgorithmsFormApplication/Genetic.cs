using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchAlgorithmsFormApplication
{
    class Genetic
    {
        int gridSize;
        Queen[] queens = new Queen[10];
        public Genetic(int gridSize, Queen[] queens)
        {
            this.gridSize = gridSize;
            this.queens = queens;
        }

        public Queen[] geneticAlgorithm(int generationSize, int elitismPercent, int crossoverProbability, int mutationProbability, int numberOfGenerations)
        {
            generationSize = generationSize - (generationSize % 2);
            int elites = elitismPercent * generationSize / 100;

            List<Queen[]> generationArray = new List<Queen[]>(generationSize);
            List<Queen[]> tempGenerationArray = new List<Queen[]>(generationSize);
            List<int> heuristics = new List<int>();

            generationArray = generateGeneration(generationArray, generationSize);  //generating random generations

            for (int i = 0; i < numberOfGenerations; i++)
            {
                for (int j = 0; j < generationSize; j++)    //heuristic values to array
                {
                    int h = Heuristic.calculateHeuristicAllBoard(generationArray[j], gridSize);
                    if (h == 0) //found a solution
                    {
                        return generationArray[j];
                    }
                    heuristics.Add(h);
                }

                generationArray = sortQueens(generationArray, heuristics);  //sorting queens

                selectQueens(generationArray, tempGenerationArray, elites); //select queens according to elitism percent

                generationArray = crossoverQueens(generationArray, crossoverProbability);

                generationArray = mutateQueens(generationArray, mutationProbability);

                generationArray.InsertRange(0, tempGenerationArray);    //insert the elites to the beginning.

                generationArray.RemoveRange(generationSize, generationArray.Count - generationSize);    //get generation size back to normal by removing generations from the end.

                heuristics.Clear();
            }
            return generationArray[0];  
        }

        private List<Queen[]> mutateQueens(List<Queen[]> generationArray, int mutationProbability)
        {
            Random rand = new Random();
            for (int i = 0; i < generationArray.Count; i++)
            {
                int mutationRand = rand.Next(0, 100);
                if (mutationRand < mutationProbability)
                {
                    int columnRand = rand.Next(0, gridSize);
                    int rowRand = rand.Next(0, gridSize);
                    generationArray[i][columnRand].setY(rowRand);
                }
            }
            return generationArray;
        }

        public void selectQueens(List<Queen[]> generationArray, List<Queen[]> tempGenerationArray, int elites)
        {
            for (int i = 0; i < elites; i++)
            {
                tempGenerationArray.Add(generationArray[i]);
            }
        }

        public List<Queen[]> crossoverQueens(List<Queen[]> generationArray, int crossoverProbability)
        {
            for (int i = 0; i < generationArray.Count; i+=2)
            {
                Random rand = new Random();
                int crossoverRand = rand.Next(0, 100);
                if (crossoverRand < crossoverProbability)
                {
                    int crossoverPos = rand.Next(0, gridSize);   //determine a random position on the board

                    for (int j = 0; j < crossoverPos; j++)      //..and crossover
                    {
                        int temp = generationArray[i][j].getY();
                        generationArray[i][j].setY(generationArray[i + 1][j].getY());
                        generationArray[i + 1][j].setY(temp);
                    }
                }
            }
            return generationArray;

        }
        public List<Queen[]> sortQueens(List<Queen[]> generationArray, List<int> heuristics)
        {
            List<Queen[]> generationArraySorted = new List<Queen[]>(generationArray);
            List<int> heuristicsCopy = new List<int>(heuristics);
            for (int i = 0; i < generationArray.Count; i++)
            {
                generationArraySorted[i] = generationArray[i];
            }
            for (int i = 0; i < heuristics.Count; i++)
            {
                heuristicsCopy[i] = heuristics[i];
            }
            heuristics.Sort();

            for (int i = 0; i < heuristicsCopy.Count; i++)
            {
                for (int j = 0; j < heuristics.Count; j++)
                {
                    if (heuristicsCopy[i] == heuristics[j])
                    {
                        int temp = j;
                        while (temp < heuristics.Count && generationArraySorted[j] != generationArray[i])
                        {
                            temp++;
                        }
                        generationArraySorted[j] = generationArray[i];
                    }
                }
            }

            return generationArraySorted;
        }
        public List<Queen[]> generateGeneration(List<Queen[]> generationArray, int generationSize)
        {
            Random rand = new Random();
            for (int i = 0; i < generationSize; i++)   //for each state
            {
                Queen[] queenArray = new Queen[gridSize];
                for (int k = 0; k < gridSize; k++)
                {
                    int row = rand.Next(0, gridSize);
                    Queen q = new Queen(k, row);
                    queenArray[k] = q;
                }
                generationArray.Add(queenArray);
            }
            return generationArray;
        }

    }
}
