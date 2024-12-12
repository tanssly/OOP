namespace lab1
{
    public class Program
    {
        public static GameAccount SelectPlayer(List<GameAccount> accounts, string prompt)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i].UserName}");
            }

            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > accounts.Count)
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

            return accounts[index - 1];
        }


        public static void Main(string[] args)
        {
            DbContext db = new DbContext();

            GameRepository gameRepository = new GameRepository(db);
            GameServices gameServices = new GameServices(gameRepository);

            GameAccountRepository accountRepository = new GameAccountRepository(db);
            GameAccountServices accountServices = new GameAccountServices(accountRepository);

            bool continuePlaying = true;

            var commandDictionary = new Dictionary<string, ICommand>
            {
                { "1", new AddPlayerCommand(accountServices) },
                { "2", new ShowPlayersCommand(accountServices) },
                { "3", new GetStatsCommand(accountServices, gameServices) },
                { "4", new PlayGameCommand(accountServices, gameServices) },
                { "5", new GetStatsGamesCommand(gameServices) }
            };

            while (continuePlaying)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new player");
                Console.WriteLine("2. Show all players");
                Console.WriteLine("3. Get player statistics");
                Console.WriteLine("4. Start a game");
                Console.WriteLine("5. Get all games statistics");
                Console.WriteLine("6. Exit");
                Console.WriteLine("7. Help");

                string input = Console.ReadLine();

                if (input == "6")
                {
                    Console.WriteLine("Goodbye!");
                    continuePlaying = false;
                }
                else if (input == "7")
                {
                    ICommand command = new ShowHelp(commandDictionary);
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                }
                else if (commandDictionary.TryGetValue(input, out ICommand command))
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }

    }
}