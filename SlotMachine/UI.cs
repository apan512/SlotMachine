using System;

namespace SlotMachine
{
    public static class UI
    {
        public static void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Welcome to our Slot Machine!");

                GetBetAmount();
                int[,] array = Logic.GenerateArray();
                DisplayArray(array);

                int choice = GetLineChoice();
                int totalWinnings = 0;

                switch (choice)
                {
                    case 1:
                        totalWinnings += Logic.CheckAllHorizontalLines(array);
                        break;
                    case 2:
                        totalWinnings += Logic.CheckCenterLine(array);
                        break;
                    case 3:
                        totalWinnings += Logic.CheckAllDiagonalLines(array);
                        break;
                    case 4:
                        totalWinnings += Logic.CheckAllVerticalLines(array);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        continue;
                }

                // Check the jackpot mode
                totalWinnings += Logic.CheckJackpotMode(array);

                Console.WriteLine($"Your total winnings are: ${totalWinnings}");

                if (totalWinnings > 0)
                {
                    Console.WriteLine("Congratulations! You won!");
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }
            }
        }

        public static int GetBetAmount()
        {
            Console.WriteLine("Enter the amount you want to bet ($3 for all three horizontal lines): ");
            int betAmount;
            bool amountChoice = int.TryParse(Console.ReadLine(), out betAmount);

            if (!amountChoice || betAmount < 3)
            {
                Console.WriteLine("Insufficient amount to play all three horizontal lines. Please enter a valid amount.");
                // Instead of exiting the program, return a value indicating an error or invalid input
                return -1; // Or any other appropriate value to indicate an error
            }

            return betAmount;
        }


        public static int GetLineChoice()
        {
            int choice;

            while (true)
            {
                Console.WriteLine("Select the line(s) you want to play:");
                Console.WriteLine($"1. {Constants.ALL_HORIZONTAL_LINES_MODE}");
                Console.WriteLine($"2. {Constants.CENTER_LINES_ONLY_MODE}");
                Console.WriteLine($"3. {Constants.ALL_DIAGONAL_LINES_MODE}");
                Console.WriteLine($"4. {Constants.ALL_VERTICAL_LINES_MODE}");

                bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (isValidChoice && choice >= Constants.MIN_GRID_CHOICE && choice <= Constants.MAX_GRID_CHOICE)
                {

                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 4.");
                }
            }
        }

        public static void DisplayArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + Constants.FREE_SPOT_STRING_CHAR);
                }
                Console.WriteLine();
            }
        }
    }
}
