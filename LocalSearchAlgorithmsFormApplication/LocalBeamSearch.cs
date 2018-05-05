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
        Queen[] queens = new Queen[10];
        int states;
        int gridSize;

        const int maxNumberOfIterations = 500;

        public LocalBeamSearch(int gridSize, Queen[] queens, int states)
        {
            this.gridSize = gridSize;
            this.queens = queens;
            this.states = states;
        }
        public Queen[] localBeamSearchAlgorithm()
        {

            //Heuristic heuristic = new Heuristic(queens, gridSize);
            List<int> heuristics = new List<int>();
            //List<Queen[]> statesArraySorted = new List<Queen[]>(states);
            

            List<Queen[]> statesArray = new List<Queen[]>();
            

            //List<List<int>> heuristicArray = new List<List<int>>();
           // int a =Heuristic.calculateHeuristicAllBoard(queens, gridSize);


            Random rand = new Random();
            for (int i = 0; i < states; i++)   //for each state
            {
                Queen[] queenArray = new Queen[gridSize];
                for (int k = 0; k < gridSize; k++)
                {
                    int row = rand.Next(0, gridSize);
                    Queen q = new Queen(k, row);
                    queenArray[k] = q;
                    queens[k] = q;
                    //queenArray[k].setY(row);

                    // h += heuristic.calculateHeuristic(queenArray[k]);
                }
                //heuristicArray.Add(heuristics);
                statesArray.Add(queenArray);
                //h = 0;
            }
     

            //queens = findSolution(statesArray);
            //statesArraySorted = sortQueens(statesArray, statesArraySorted, heuristics, heuristicsCopy);
            for (int k = 0; k < maxNumberOfIterations; k++) //for each desired number of iterations.
            {
                List<Queen[]> NewStatesArray = new List<Queen[]>();
                //List<Queen[]> statesArraySorted = new List<Queen[]>(states);
                for (int i = 0; i < statesArray.Count; i++)
                {
                   
                    int h = Heuristic.calculateHeuristicAllBoard(statesArray[i], gridSize);
                    if (h == 0)
                        return statesArray[i];
                    heuristics.Add(h);

                    NewStatesArray = makeMove(statesArray, h);
                }
                //List<int> heuristicsCopy = new List<int>(states);
                NewStatesArray =sortQueens(statesArray,heuristics);   
                statesArray.Clear();
                heuristics.Clear();
                for(int l = 0; l< states; l++)  //for desired number of states elected
                {
                    statesArray.Add(NewStatesArray[l]);
                }
            }

            return queens;
        }
        public List<Queen[]> makeMove(List<Queen[]> statesArray, int heuristic)
        {
            for (int i = 0; i < statesArray.Count; i++)     //for each state
            {
                for (int j = 0; j < gridSize; j++)          //for each column
                {
                    int tempY = statesArray[i][j].getY();
                    for (int k =0; k< gridSize; k++)        //for each row
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
            List<Queen[]> statesArraySorted = new List<Queen[]>(statesArray);
            List<int> heuristicsCopy = new List<int>(heuristics);
            for (int i = 0; i < statesArray.Count; i++)
            {
                statesArraySorted[i]=statesArray[i];
            }

            // statesArraySorted = statesArray;
            for (int i = 0; i < heuristics.Count; i++)
            {
                heuristicsCopy[i] =heuristics[i];
            }
            //heuristicsCopy = heuristics;
            heuristics.Sort();

            for (int i = 0; i < heuristicsCopy.Count; i++)
            {
                for (int j = 0; j < heuristics.Count; j++)
                {
                    if (heuristicsCopy[i] == heuristics[j])
                    {
                        int temp = j;
                        while (temp < heuristics.Count && statesArraySorted[j] != statesArray[i])
                        {
                            temp++;
                            //j++;
                        }
                        statesArraySorted[j] = statesArray[i];
                    }
                }
            }

            return statesArraySorted;
        }


        //public static List<T> DeepClone<T>(this List<T> items)
        //{
        //    var query = from T item in items select item.DeepClone();
        //    return new List<T>(query);
        //}
    }
}
