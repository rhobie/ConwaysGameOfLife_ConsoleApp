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

            int[,] arr = new int[size, size];

            PrintArray(arr);
            Console.Read();
            //arr[10, 10] = 1;
            //arr[10, 11] = 1;
            //arr[9, 10] = 1;
            //PrintArray(arr);
            //Console.Read();
            RandomlyPopulateArray(arr);
            PrintArray(arr);
            Console.Read();

            for (int i = 0; i < 10000; i++)
            {
                CalcualteNewNumbers(arr);
                PrintArray(arr);
                Console.Read();
            }

            Console.Read();
        }

        static void CalcualteNewNumbers(int[,] arr)
        {
            //traverse array, for each of each elements neighbours check the cells around it

            //if cell is one, and it has less than 2 alive neighbours OR more than 3 neighbours, set it to zero
            //if cell is zero and it has 3 neighbours set it to one

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    //this really needs to be rewritten...
                    //count neighbours
                    int aliveNeighbours = 0;
                    if (i - 1 > 0 && arr[i - 1, j + 0] == 1) //left
                        aliveNeighbours++;
                    if (i + 1 < arr.GetLength(0) - 1 && arr[i + 1, j + 0] == 1) //right
                        aliveNeighbours++;
                    if (i - 1 > 0 && j + 1 < arr.GetLength(0) - 1 && arr[i - 1, j + 1] == 1) //bottom left
                        aliveNeighbours++;
                    if (i + 1 < arr.GetLength(0) - 1 && j + 1 < arr.GetLength(0) - 1 && arr[i + 1, j + 1] == 1) //bottom right 
                        aliveNeighbours++;
                    if (i + 1 < arr.GetLength(0) - 1 && j - 1 > 0 && arr[i + 1, j - 1] == 1) //top right
                        aliveNeighbours++;
                    if (i - 1 > 0 && j - 1 > 0 && arr[i - 1, j - 1] == 1) //top left
                        aliveNeighbours++;
                    if (j + 1 < arr.GetLength(0) - 1 && arr[i + 0, j + 1] == 1) //down
                        aliveNeighbours++;
                    if (j - 1 > 0 && arr[i + 0, j - 1] == 1) //up
                        aliveNeighbours++;

                    if (aliveNeighbours < 2 || aliveNeighbours > 3)
                    {
                        arr[i, j] = 0;
                    }
                    else if (aliveNeighbours == 3)
                    {
                        arr[i, j] = 1;
                    }
                }
            }
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

        //Console.
        //static ref int[] CreateBlankArray(int cols, int rows)
        //{
        //    int[] arrRows = new int[rows];
        //    for (int i = 0; i < col; i++)
        //    {

        //    }


        //    return ref arrRows[];
        //}

        //void PrintArray(int[] arr)
        //{

        //}
    }
}
