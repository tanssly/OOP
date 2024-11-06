using System;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Зчитування імен гравців з консолі
            Console.WriteLine("Enter the name of the first player:");
            string player1Name = Console.ReadLine();
            GameAccount player1 = new GameAccount(player1Name);

            Console.WriteLine("Enter the name of the second player:");
            string player2Name = Console.ReadLine();
            GameAccount player2 = new GameAccount(player2Name);

            // Імітація ігор
            try
            {
                Console.WriteLine("Simulating games between players...");
                player1.WinGame(player2Name, 30);
                player2.LoseGame(player1Name, 30);

                player2.WinGame(player1Name, 50);
                player1.LoseGame(player2Name, 50);

                player1.WinGame(player2Name, 20);
                player2.LoseGame(player1Name, 20);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Виведення статистики гравців
            Console.WriteLine("\nPlayer Statistics:");
            player1.GetStats();
            player2.GetStats();
        }
    }
}
