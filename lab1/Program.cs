using lab1;

class Program
{
    static void Main(string[] args)
    {
        DbContext db = new DbContext();

        // Create repositories and services
        GameRepository gameRepository = new GameRepository(db);
        GameServices gameServices = new GameServices(gameRepository);
        GameAccountRepository accountRepository = new GameAccountRepository(db);
        GameAccountServices accountServices = new GameAccountServices(accountRepository);

        bool continuePlaying = true;

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Start a game");
            Console.WriteLine("3. Show all players");
            Console.WriteLine("4. Show games by player");
            Console.WriteLine("5. Show all games");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter player name: ");
                    string playerName = Console.ReadLine();
                    Console.Write("Enter player rating: ");
                    int rating = int.Parse(Console.ReadLine());

                    // Create and add player
                    GameAccount newPlayer = new StandardAccount(playerName, rating);
                    accountServices.AddGameAccount(newPlayer);
                    Console.WriteLine("Player added.");
                    break;

                case "2":
                    Console.Write("Enter player name: ");
                    string p1 = Console.ReadLine();
                    Console.Write("Enter opponent name: ");
                    string p2 = Console.ReadLine();
                    Console.Write("Enter number of games: ");
                    int numberOfGames = int.Parse(Console.ReadLine());

                    // Get players by name
                    GameAccount player1 = accountServices.GetAccountByUserName(p1);
                    GameAccount player2 = accountServices.GetAccountByUserName(p2);

                    // Create game instance
                    Game game = GameFactory.CreateGames(1, player1, player2);

                    // Call PlayGame with correct parameters
                    gameServices.PlayGame(gameServices, numberOfGames, game, player1, player2);
                    Console.WriteLine("Game played and results saved.");
                    break;

                case "3":
                    Console.WriteLine("All Players:");
                    foreach (var player in accountServices.ReadAll())
                    {
                        Console.WriteLine($"{player.Id}: {player.UserName} - Rating: {player.CurrentRating}");
                    }
                    break;

                case "4":
                    Console.Write("Enter player name: ");
                    string searchName = Console.ReadLine();
                    var games = gameServices.ReadAll().Where(g => g.OpponentName == searchName || g.OpponentName == searchName).ToList();
                    foreach (var gameHistory in games)
                    {
                        Console.WriteLine($"Game {gameHistory.GameIndex}: {gameHistory.OpponentName} vs {gameHistory.OpponentName} - {gameHistory.Result} ({gameHistory.Rating} points)");
                    }
                    break;

                case "5":
                    Console.WriteLine("All Games:");
                    foreach (var gameHistory in gameServices.ReadAll())
                    {
                        Console.WriteLine($"Game {gameHistory.GameIndex}: {gameHistory.OpponentName} vs {gameHistory.OpponentName} - {gameHistory.Result} ({gameHistory.Rating} points)");
                    }
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
