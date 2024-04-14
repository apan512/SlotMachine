using System;

namespace SlotMachine
{
    public class Logic
    {
        private static Random rnd = new Random();

        public static int[,] GenerateArray()
        {
            int[,] array = new int[Constants.FIRST_GRID, Constants.SECOND_GRID];

            for (int i = 0; i < Constants.FIRST_GRID; i++)
            {
                for (int j = 0; j < Constants.SECOND_GRID; j++)
                {
                    array[i, j] = rnd.Next(Constants.MIN_NUMBER, Constants.MAX_NUMBER);
                }
            }

            return array;
        }

        // Checking lines Method

        public static int CheckJackpotMode(int[,] array)
        {
            int totalWinnings = 0;

            // Check if all rows, columns, and diagonals are equal
            // If so, you hit the jackpot

            return totalWinnings;
        }
    }
}