using System;

namespace SlotMachine
{
    public class UI
    {
        public static int GetBetAmount()
        {
            Console.WriteLine("Enter the amount you want to bet ($3 for all three horizontal lines): ");
            int betAmount;
            bool amountChoice = int.TryParse(Console.ReadLine(), out betAmount);

            if (!amountChoice || betAmount < 3)
            {
                Console.WriteLine("Insufficient amount to play all three horizontal lines. Exiting...");
                Environment.Exit(0);
            }

            return betAmount;
        }

        public static int GetLineChoice()
        {
            Console.WriteLine("Select the line(s) you want to play:");
            Console.WriteLine("1. All horizontal lines");
            Console.WriteLine("2. Center line only");
            Console.WriteLine("3. All diagonal lines");
            Console.WriteLine("4. All vertical lines");

            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            if (!isValidChoice || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a valid number between 1 and 4.");
                Environment.Exit(0);
            }

            return choice;
        }

        public static void DisplayArray(int[,] array)
        {
            for (int i = 0; i < Constants.FIRST_GRID; i++)
            {
                for (int j = 0; j < Constants.SECOND_GRID; j++)
                {
                    Console.Write(array[i, j] + Constants.FREE_SPOT_STRING_CHAR);
                }
                Console.WriteLine();
            }
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayWinnings(int totalWinnings)
        {
            Console.WriteLine($"Your total winnings are: ${totalWinnings}");
        }

        public static void DisplayResult(bool win)
        {
            if (!win)
            {
                Console.WriteLine("You lost");
            }
        }
    }
}