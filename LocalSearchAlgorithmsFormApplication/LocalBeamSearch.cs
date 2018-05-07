using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//maybe don't pass Queen[] queens as reference...................
namespace LocalSearchAlgorithmsFormApplication
{
    class LocalBeamSearch
    {
        int states;
        int gridSize;

        const int maxNumberOfIterations = 500;

        public LocalBeamSearch(int gridSize, int states)
        {
            this.gridSize = gridSize;
            this.states = states;
        }
        public Queen[] localBeamSearchAlgorithm()
        {
            List<int> heuristics = new List<int>();
            List<Queen[]> statesArray = new List<Queen[]>();
            Random rand = new Random();

            for (int i = 0; i < states; i++)   //for each state
            {
                Queen[] queenArray = new Queen[gridSize];
                for (int k = 0; k < gridSize; k++)
                {
                    int row = rand.Next(0, gridSize);
                    Queen q = new Queen(k, row);
                    queenArray[k] = q;
                }
                statesArray.Add(queenArray);
            }

            for (int k = 0; k < maxNumberOfIterations; k++) //for each desired number of iterations.
            {
                List<Queen[]> NewStatesArray = new List<Queen[]>();

                for (int i = 0; i < statesArray.Count; i++)
                {
                    int h = Heuristic.calculateHeuristicAllBoard(statesArray[i], gridSize);
                    if (h == 0)
                        return statesArray[i];
                    heuristics.Add(h);

                    NewStatesArray = makeMove(statesArray, h);
                }

                NewStatesArray = sortQueens(statesArray, heuristics);
                statesArray.Clear();
                heuristics.Clear();

                for (int l = 0; l < states; l++)  //for desired number of states elected
                {
                    statesArray.Add(NewStatesArray[l]);
                }
            }

            return statesArray[0];
        }
        public List<Queen[]> makeMove(List<Queen[]> statesArray, int heuristic)
        {
            for (int i = 0; i < statesArray.Count; i++)     //for each state
            {
                for (int j = 0; j < gridSize; j++)          //for each column
                {
                    int tempY = statesArray[i][j].getY();
                    for (int k = 0; k < gridSize; k++)        //for each row
                    {
                        if (k == tempY)
                            continue;
                        statesArray[i][j].setY(k);
                        if (Heuristic.calculateHeuristicAllBoard(statesArray[i], gridSize) >= heuristic)
                        {
                            statesArray[i][j].setY(tempY);
                        }
                        else
                            break;
                    }
                }
            }
            return statesArray;
        }

        public List<Queen[]> sortQueens(List<Queen[]> statesArray, List<int> heuristics)
        {
            List<Queen[]> statesArraySorted = new List<Queen[]>();
            List<int> heuristicsCopy = new List<int>();

            statesArraySorted.AddRange(statesArray);
            heuristicsCopy.AddRange(heuristics);
            heuristics.Sort();

            //for (int i = 0; i < heuristicsCopy.Count; i++)
            //{
            //    for (int j = 0; j < heuristics.Count; j++)
            //    {
            //        if (heuristicsCopy[i] == heuristics[j])
            //        {
            //            int temp = j;
            //            while (temp < heuristics.Count && statesArraySorted[j] != statesArray[i])
            //            {
            //                temp++;
            //                //j++;
            //            }
            //            statesArraySorted[j] = statesArray[i];
            //        }
            //    }
            //}
            List<int> index = new List<int>();
            for (int i = 0; i < heuristicsCopy.Count; i++)
            {
                for (int j = 0; j < heuristics.Count; j++)
                {
                    if (heuristicsCopy[i] == heuristics[j])
                    {
                        if (index.Contains(j))
                            continue;
                        statesArraySorted[j] = statesArray[i];
                        index.Add(j);
                        break;
                    }
                }
            }
            return statesArraySorted;
        }
    }
}
