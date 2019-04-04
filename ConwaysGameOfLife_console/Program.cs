using System;

namespace ConwaysGameOfLife_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //need to make it update all points after checking them...
            //this can be done with 2 arrays

            int size = 20;

            //ROWS ARE FIRST
            int[,] arr = new int[size, size];

            PrintArray(arr);
            arr[10, 10] = 1;
            arr[10, 11] = 1;
            arr[10, 12] = 1;
            arr[10, 13] = 1;
            arr[10, 14] = 1;
            arr[9, 10] = 1;

            //should repeat:
            arr[4, 3] = 1;
            arr[4, 4] = 1;
            arr[4, 5] = 1;

            PrintArray(arr);
            
            //RandomlyPopulateArray(arrBefore);
            PrintArray(arr); //WTF? IF I TURN THIS OFF IT SHOWS THE NEIGHBOURS AS THE CELLS AND STILL WORKS?

            for (int i = 0; i < 10000; i++)
            {
                arr = CalcualteNewNumbers(arr);
                PrintArray(arr);
            }
        }

        static int[,] CalcualteNewNumbers(int[,] _arrBefore)
        {
            int[,] arrAfter = new int[_arrBefore.GetLength(0), _arrBefore.GetLength(1)];

            //traverse array, at each point count the live neighbours each cell has around it
            for (int row = 0; row < _arrBefore.GetLength(0); row++)
            {
                for (int col = 0; col < _arrBefore.GetLength(1); col++)
                {
                    int aliveNeighbours = 0;

                    if (row - 1 > 0)  //UP
                        aliveNeighbours += _arrBefore[row - 1, col + 0];

                    if (row + 1 < _arrBefore.GetLength(0) - 1) //DOWN
                        aliveNeighbours += _arrBefore[row + 1, col + 0];

                    if (row - 1 > 0 && col + 1 < _arrBefore.GetLength(1) - 1) //UPPER RIGHT
                        aliveNeighbours += _arrBefore[row - 1, col + 1];

                    if (row + 1 < _arrBefore.GetLength(0) - 1 && col + 1 < _arrBefore.GetLength(1) - 1) //LOWER RIGHT
                        aliveNeighbours += _arrBefore[row + 1, col + 1];

                    if (row + 1 < _arrBefore.GetLength(0) - 1 && col - 1 > 0) //LOWER LEFT
                        aliveNeighbours += _arrBefore[row + 1, col - 1];

                    if (row - 1 > 0 && col - 1 > 0) // UPPER LEFT
                        aliveNeighbours += _arrBefore[row - 1, col - 1];

                    if (col + 1 < _arrBefore.GetLength(1) - 1) //RIGHT
                        aliveNeighbours += _arrBefore[row + 0, col + 1];

                    if (col - 1 > 0) //LEFT
                        aliveNeighbours += _arrBefore[row + 0, col - 1];

                    arrAfter[row, col] = aliveNeighbours;
                }
            }
            PrintArray(arrAfter);

            //assign values to new array based on amount of alive neighbours

            //-If the cell is alive, then it stays alive if it has either 2 or 3 live neighbors
            //-If the cell is dead, then it springs to life only in the case that it has 3 live neighbors
            for (int row = 0; row < _arrBefore.GetLength(0); row++)
            {
                for (int col = 0; col < _arrBefore.GetLength(1); col++)
                {
                    if (_arrBefore[row, col] == 1)
                    {
                        if (arrAfter[row, col] == 2 || arrAfter[row, col] == 3)
                            arrAfter[row, col] = 1;
                        else
                            arrAfter[row, col] = 0;
                    }
                    else if (arrAfter[row, col] == 3)
                        arrAfter[row, col] = 1;
                    else
                        arrAfter[row, col] = 0;
                }
            }
            return arrAfter;   
        }

        static void PrintArray(int[,] arr)
        {
            Console.Clear();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        static void RandomlyPopulateArray(int[,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(2);
                }
            }
        }
    }
}
