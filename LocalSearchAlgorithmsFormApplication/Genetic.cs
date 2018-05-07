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

        public Genetic(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public Queen[] geneticAlgorithm(int generationSize, int elitismPercent, int crossoverProbability, int mutationProbability, int numberOfGenerations)
        {
            generationSize = generationSize - (generationSize % 2);
            int elites = elitismPercent * generationSize / 100;

            Queen[][] generationArray = new Queen[generationSize][];
            Queen[][] tempGenerationArray = new Queen[elites][];
            List<int> heuristics = new List<int>();

            generationArray = generateGeneration(generationArray, generationSize);  //generating random generations

            for (int i = 0; i < numberOfGenerations; i++)   //main loop
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
            
                tempGenerationArray = selectQueens(generationArray, elites); //select queens according to elitism percent

                generationArray = crossoverQueens(generationArray, crossoverProbability);

                generationArray = mutateQueens(generationArray, mutationProbability);

                List<Queen[]> list = new List<Queen[]>(generationArray);    //converting array to list to be able to use inserRange and removeRange methods.
               
                list.InsertRange(0, tempGenerationArray);    //insert the elites to the beginning.
                list.RemoveRange(generationSize, list.Count - generationSize);    //get generation size back to normal by removing generations from the end.
                generationArray = list.ToArray();

                heuristics.Clear();
            }
            return generationArray[0];
        }

        private Queen[][] mutateQueens(Queen[][] generationArray, int mutationProbability)
        {
            Random rand = new Random();
            for (int i = 0; i < generationArray.Length; i++)
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

        public Queen[][] selectQueens(Queen[][] generationArray, int elites)
        {
            Queen[][] tempGenerationArray = new Queen[elites][];

            for (int i = 0; i < elites; i++)
            {
                Queen[] qa = new Queen[gridSize];
                for (int j = 0; j < gridSize; j++)
                {
                    Queen q = new Queen(generationArray[i][j].getX(), generationArray[i][j].getY());
                    qa[j] = q;
                }
                tempGenerationArray[i] = qa;
            }
            return tempGenerationArray;
        }

        public Queen[][] crossoverQueens(Queen[][] generationArray, int crossoverProbability)
        {
            for (int i = 0; i < generationArray.Length; i += 2)
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
        public Queen[][] sortQueens(Queen[][] generationArray, List<int> heuristics)
        {
            Queen[][] generationArraySorted = new Queen[generationArray.Length][];
            List<int> heuristicsCopy = new List<int>(heuristics);
          
            heuristics.Sort();
            List<int> index = new List<int>();
            for (int i = 0; i < heuristicsCopy.Count; i++)
            {
                for (int j = 0; j < heuristics.Count; j++)
                {
                    if (heuristicsCopy[i] == heuristics[j])
                    {
                        if (index.Contains(j))
                            continue;
                        generationArraySorted[j] = generationArray[i];
                        index.Add(j);
                        break;
                    }
                }
            }
            return generationArraySorted;
        }
        public Queen[][] generateGeneration(Queen[][] generationArray, int generationSize)
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
                generationArray[i] = queenArray;
            }
            return generationArray;
        }

    }
}
