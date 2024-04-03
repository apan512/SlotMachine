using System;

namespace SlotMachine
{
    internal class Program
    {
        const int MIN_NUMBER = 0;
        const int MAX_NUMBER = 10;
        const int FIRST_ARRAY = 3;
        const int SECOND_ARRAY = 3;
        const int GRID_SIZE = 3;
        const int EARN_EQUAL = 1;

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welcome to our Slot Machine!");
                Console.WriteLine("Enter the amount you want to bet ($3 for all three horizontal lines): ");
                int betAmount = Convert.ToInt32(Console.ReadLine());

                if (betAmount < 3)
                {
                    Console.WriteLine("Insufficient amount to play all three horizontal lines. Exiting...");
                    return;
                }

                int totalWinings = 0;

                Random rnd = new Random();
                int[,] Array2D = new int[FIRST_ARRAY, SECOND_ARRAY];

                for (int i = 0; i < FIRST_ARRAY; i++)
                {
                    for (int j = 0; j < SECOND_ARRAY; j++)
                    {
                        Array2D[i, j] = rnd.Next(MIN_NUMBER, MAX_NUMBER);
                    }
                }

                for (int i = 0; i < FIRST_ARRAY; i++)
                {
                    for (int j = 0; j < SECOND_ARRAY; j++)
                    {
                        Console.Write(Array2D[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                bool win = false;
                bool rowEqual = true;
                bool colEqual = true;
                bool diagEqual = true;


                //Diagonal

                for (int k = 1; k < GRID_SIZE; k++)
                {
                    if (Array2D[k, k] != Array2D[0, 0])
                    {
                        diagEqual = false;
                        break;
                    }
                }
                if (diagEqual)
                {
                    Console.WriteLine($"All numbers from the main diagonal are equal: {Array2D[0, 0]}");
                    totalWinings += EARN_EQUAL;
                    win = true;
                }

                //Row

                for (int i = 0; i < GRID_SIZE; i++)
                {

                    for (int j = 1; j < GRID_SIZE; j++)
                    {
                        if (Array2D[i, j] != Array2D[i, 0])
                        {
                            rowEqual = false;
                            break;
                        }
                    }

                    if (rowEqual)
                    {
                        Console.WriteLine($"All numbers from row {i + 1} are equal: {Array2D[i, 0]}");
                        totalWinings += EARN_EQUAL;
                        win = true;
                    }
                }

                //Column

                for (int i = 0; i < GRID_SIZE; i++)
                {

                    for (int j = 1; j < GRID_SIZE; j++)
                    {
                        if (Array2D[j, i] != Array2D[0, i])
                        {
                            colEqual = false;
                            break;
                        }
                    }

                    if (colEqual)
                    {
                        Console.WriteLine($"All numbers from column {i + 1} are equal: {Array2D[0, i]}");
                        totalWinings += EARN_EQUAL;
                        win = true;
                    }

                }


                Console.WriteLine($"Your total winnings are: ${totalWinings}");

                if (!win)
                {
                    Console.WriteLine("You lost");
                }
            }
        }
    }
}