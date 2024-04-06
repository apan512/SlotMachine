using System;

namespace SlotMachine
{
    internal class Program
    {
        const int MIN_NUMBER = 0;
        const int MAX_NUMBER = 10;
        const int FIRST_GRID = 5;
        const int SECOND_GRID = 5;
        const int GRID_SIZE = 3;
        const int EARN_EQUAL = 1;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to our Slot Machine!");
                Console.WriteLine("Enter the amount you want to bet ($3 for all three horizontal lines): ");
                int betAmount;
                bool amountChoice = int.TryParse(Console.ReadLine(), out betAmount);

                if (!amountChoice || betAmount < 3)
                {
                    Console.WriteLine("Insufficient amount to play all three horizontal lines. Exiting...");
                    return;
                }

                bool win = false;
                int totalWinnings = 0;

                Console.WriteLine("Select the line(s) you want to play:");
                Console.WriteLine("1. All horizontal lines");
                Console.WriteLine("2. Center line only");
                Console.WriteLine("3. All diagonal lines");
                Console.WriteLine("4. All vertical lines");

                int choice;
                bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                int[,] Array2D = new int[FIRST_GRID, SECOND_GRID];

                for (int i = 0; i < FIRST_GRID; i++)
                {
                    for (int j = 0; j < SECOND_GRID; j++)
                    {
                        Array2D[i, j] = rnd.Next(MIN_NUMBER, MAX_NUMBER);
                    }
                }

                for (int i = 0; i < FIRST_GRID; i++)
                {
                    for (int j = 0; j < SECOND_GRID; j++)
                    {
                        Console.Write(Array2D[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                if (!isValidChoice || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        totalWinnings += CheckAllHorizontalLines(Array2D);
                        break;
                    case 2:
                        totalWinnings += CheckCenterLine(Array2D);
                        break;
                    case 3:
                        totalWinnings += CheckAllDiagonalLines(Array2D);
                        break;
                    case 4:
                        totalWinnings += CheckAllVerticalLines(Array2D);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        continue;
                }

                Console.WriteLine($"Your total winnings are: ${totalWinnings}");

                if (totalWinnings > 0)
                {
                    win = true;
                }

                if (!win)
                {
                    Console.WriteLine("You lost");
                }
            }
        }

        // Playing all horizontal lines
        static int CheckAllHorizontalLines(int[,] array)
        {
            int totalWinnings = 0;
            for (int i = 0; i < GRID_SIZE; i++)
            {
                bool rowEqual = true;
                for (int j = 1; j < GRID_SIZE; j++)
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
                    totalWinnings += EARN_EQUAL;
                }
            }
            return totalWinnings;
        }

        // Playing the center line only
        static int CheckCenterLine(int[,] array)
        {
            int totalWinnings = 0;
            int centerRow = array.GetLength(0) / 2; // Calculate the center row
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
                totalWinnings += EARN_EQUAL;
            }
            return totalWinnings;
        }

        // Playing all diagonal lines
        static int CheckAllDiagonalLines(int[,] array)
        {
            int totalWinnings = 0;
            bool diagonal1Equal = true;
            bool diagonal2Equal = true;
            for (int i = 1; i < GRID_SIZE; i++)
            {
                if (array[i, i] != array[0, 0])
                {
                    diagonal1Equal = false;
                }
                if (array[i, GRID_SIZE - 1 - i] != array[0, GRID_SIZE - 1])
                {
                    diagonal2Equal = false;
                }
            }
            if (diagonal1Equal)
            {
                Console.WriteLine($"All numbers from the main diagonal are equal: {array[0, 0]}");
                totalWinnings += EARN_EQUAL;
            }
            if (diagonal2Equal)
            {
                Console.WriteLine($"All numbers from the secondary diagonal are equal: {array[0, GRID_SIZE - 1]}");
                totalWinnings += EARN_EQUAL;
            }
            return totalWinnings;
        }

        // Playing all vertical lines
        static int CheckAllVerticalLines(int[,] array)
        {
            int totalWinnings = 0;
            for (int i = 0; i < GRID_SIZE; i++)
            {
                bool columnEqual = true;
                for (int j = 1; j < GRID_SIZE; j++)
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
                    totalWinnings += EARN_EQUAL;
                }
            }
            return totalWinnings;
        }
    }
}
