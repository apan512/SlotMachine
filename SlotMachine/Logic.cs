using System;

namespace SlotMachine
{
    public static class Logic
    {
        private static readonly Random rnd = new Random();

        public static int[,] GenerateArray()
        {
            int[,] array = new int[Constants.GRID_SIZE, Constants.GRID_SIZE];

            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    array[i, j] = rnd.Next(Constants.MIN_NUMBER, Constants.MAX_NUMBER);
                }
            }

            return array;
        }

        public static int CheckAllHorizontalLines(int[,] array)
        {
            int totalWinnings = 0;
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                bool rowEqual = true;
                for (int j = 1; j < Constants.GRID_SIZE; j++)
                {
                    if (array[i, j] != array[i, 0])
                    {
                        rowEqual = false;
                        break;
                    }
                }
                if (rowEqual)
                {
                    Console.WriteLine($"All numbers from row {i + 1} are equal: {array[i, 0]}");
                    totalWinnings += Constants.EARN_EQUAL;
                }
            }
            return totalWinnings;
        }

        public static int CheckCenterLine(int[,] array)
        {
            int totalWinnings = 0;
            int centerRow = array.GetLength(0) / 2;
            bool rowEqual = true;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[centerRow, j] != array[centerRow, 0])
                {
                    rowEqual = false;
                    break;
                }
            }
            if (rowEqual)
            {
                Console.WriteLine($"All numbers from the center line are equal: {array[centerRow, 0]}");
                totalWinnings += Constants.EARN_EQUAL;
            }
            return totalWinnings;
        }

        public static int CheckAllDiagonalLines(int[,] array)
        {
            int totalWinnings = 0;
            bool diagonal1Equal = true;
            bool diagonal2Equal = true;
            for (int i = 1; i < Constants.GRID_SIZE; i++)
            {
                if (array[i, i] != array[0, 0])
                {
                    diagonal1Equal = false;
                }
                if (array[i, Constants.GRID_SIZE - 1 - i] != array[0, Constants.GRID_SIZE - 1])
                {
                    diagonal2Equal = false;
                }
            }
            if (diagonal1Equal)
            {
                Console.WriteLine($"All numbers from the main diagonal are equal: {array[0, 0]}");
                totalWinnings += Constants.EARN_EQUAL;
            }
            if (diagonal2Equal)
            {
                Console.WriteLine($"All numbers from the secondary diagonal are equal: {array[0, Constants.GRID_SIZE - 1]}");
                totalWinnings += Constants.EARN_EQUAL;
            }
            return totalWinnings;
        }

        public static int CheckAllVerticalLines(int[,] array)
        {
            int totalWinnings = 0;
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                bool columnEqual = true;
                for (int j = 1; j < Constants.GRID_SIZE; j++)
                {
                    if (array[j, i] != array[0, i])
                    {
                        columnEqual = false;
                        break;
                    }
                }
                if (columnEqual)
                {
                    Console.WriteLine($"All numbers from column {i + 1} are equal: {array[0, i]}");
                    totalWinnings += Constants.EARN_EQUAL;
                }
            }
            return totalWinnings;
        }

        public static int CheckJackpotMode(int[,] array)
        {
            int totalWinnings = 0;

            bool allRowsEqual = true;
            bool allColumnsEqual = true;
            bool mainDiagonalEqual = true;
            bool secondDiagonalEqual = true;

            // Check all rows
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 1; j < Constants.GRID_SIZE; j++)
                {
                    if (array[i, j] != array[i, 0])
                    {
                        allRowsEqual = false;
                        break;
                    }
                }
            }

            // Check all columns
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                for (int i = 1; i < Constants.GRID_SIZE; i++)
                {
                    if (array[i, j] != array[0, j])
                    {
                        allColumnsEqual = false;
                        break;
                    }
                }
            }

            // Check main diagonal
            for (int i = 1; i < Constants.GRID_SIZE; i++)
            {
                if (array[i, i] != array[0, 0])
                {
                    mainDiagonalEqual = false;
                    break;
                }
            }

            // Check second diagonal
            for (int i = 1; i < Constants.GRID_SIZE; i++)
            {
                if (array[i, Constants.GRID_SIZE - 1 - i] != array[0, Constants.GRID_SIZE - 1])
                {
                    secondDiagonalEqual = false;
                    break;
                }
            }

            // If all rows, columns, and diagonals are equal, you have a jackpot
            if (allRowsEqual && allColumnsEqual && mainDiagonalEqual && secondDiagonalEqual)
            {
                Console.WriteLine("We have a winner! You hit the jackpot!");
                totalWinnings += Constants.EARN_EQUAL * Constants.GRID_SIZE * 2;
            }

            return totalWinnings;
        }
    }
}
