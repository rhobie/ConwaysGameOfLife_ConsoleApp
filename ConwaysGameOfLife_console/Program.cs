using System;

namespace ConwaysGameOfLife_console
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = Console.LargestWindowWidth;// 50; //Console.LargestWindowWidth;
            int height = Console.LargestWindowHeight;// 50;//Console.LargestWindowHeight;

            Console.SetWindowSize(width, height);
            Console.ForegroundColor = ConsoleColor.Green;

            if (width == Console.LargestWindowWidth) //minus 4 from width so that columns fit
                width -= 4;
            if (height == Console.LargestWindowHeight) // minus 1 from height so that columns fit
                height -= 1;
            int[,] arr = new int[height, width];

            ////blinker:
            //arr[4, 3] = 1;
            //arr[4, 4] = 1;
            //arr[4, 5] = 1;

            ////toad:
            //arr[20, 20] = 1;
            //arr[20, 21] = 1;
            //arr[20, 22] = 1;
            //arr[21, 21] = 1;
            //arr[21, 22] = 1;
            //arr[21, 23] = 1;

            //PrintArray(arr);
            
            RandomlyPopulateArray(arr);
            PrintArray(arr);

            for (int i = 0; i < 10000; i++)
            {
                PrintArray(arr);
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

                    //should really be done as a loop instead of this massive IF block
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
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sb.Append(arr[i, j]);
                }
                sb.AppendLine();
            }
            Console.Write(sb);
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
