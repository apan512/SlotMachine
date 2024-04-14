using System;

namespace SlotMachine
{
    public class Data
    {
        public static void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Welcome to our Slot Machine!");

                int betAmount = UI.GetBetAmount();
                int[,] array = Logic.GenerateArray();
                UI.DisplayArray(array);

                int choice = UI.GetLineChoice();
                int totalWinnings = 0;

                switch (choice)
                {
                    case 1:
                        // Check all horizontal lines
                        break;
                    case 2:
                        // Check center line
                        break;
                    case 3:
                        // Check all diagonal lines
                        break;
                    case 4:
                        // Check all vertical lines
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        continue;
                }

                totalWinnings += Logic.CheckJackpotMode(array);

                UI.DisplayWinnings(totalWinnings);

                bool win = totalWinnings > 0;
                UI.DisplayResult(win);
            }
        }
    }
}