public class Program
{
    public static void Main()
    {
        List<GameAccount> players = new List<GameAccount>();
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Start a game");
            Console.WriteLine("3. Show player stats");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter player name: ");
                    string playerName = Console.ReadLine();
                    Console.WriteLine("Choose account type: 1-Standard, 2-Victory Streak, 3-Reduced Penalty");
                    int type = int.Parse(Console.ReadLine());

                    GameAccount account = type switch
                    {
                        1 => new StandardAccount(playerName),
                        2 => new VictoryStreakAccount(playerName),
                        3 => new ReducedPenaltyAccount(playerName),
                        _ => throw new ArgumentException("Invalid account type")
                    };

                    players.Add(account);
                    Console.WriteLine($"Player '{playerName}' added.");
                    break;

                case "2": // Start a game
                    if (players.Count < 2)
                    {
                        Console.WriteLine("At least two players are required to start a game.");
                        break;
                    }

                    // Choose game type
                    Console.WriteLine("Choose game type: 1-Standard, 2-Training, 3-Solo");
                    int gameType = int.Parse(Console.ReadLine());

                    // Create game based on selected type
                    Game game = gameType switch
                    {
                        1 => GameFactory.CreateGame("Standard", players.Count + 1, "Opponent", "Pending", 50),
                        2 => GameFactory.CreateGame("Training", players.Count + 1, "Opponent", "Pending", 0),
                        3 => GameFactory.CreateGame("Solo", players.Count + 1, "None", "Pending", 25),
                        _ => throw new ArgumentException("Invalid game type")
                    };

                    // Choose players for the game
                    Console.WriteLine("Available players:");
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {players[i].UserName}");
                    }

                    int player1Index = -1;
                    int player2Index = -1;

                    while (player1Index < 0 || player1Index >= players.Count)
                    {
                        Console.WriteLine("Enter player number for Player 1: ");
                        player1Index = int.Parse(Console.ReadLine()) - 1;
                        if (player1Index < 0 || player1Index >= players.Count)
                        {
                            Console.WriteLine("Invalid player number. Try again.");
                        }
                    }

                    while (player2Index < 0 || player2Index >= players.Count || player2Index == player1Index)
                    {
                        Console.WriteLine("Enter player number for Player 2: ");
                        player2Index = int.Parse(Console.ReadLine()) - 1;
                        if (player2Index < 0 || player2Index >= players.Count)
                        {
                            Console.WriteLine("Invalid player number. Try again.");
                        }
                        if (player2Index == player1Index)
                        {
                            Console.WriteLine("Player 2 cannot be the same as Player 1. Try again.");
                        }
                    }

                    GameAccount player1 = players[player1Index];
                    GameAccount player2 = players[player2Index];

                    // Enter rating for the game
                    Console.Write("Enter rating for the game: ");
                    int rating = int.Parse(Console.ReadLine());

                    // Simulate the game result
                    game.Play(player1, player2, rating);

                    // Update game history and ratings
                    player1.WinGame(game, rating);  // Player 1 wins
                    player2.LoseGame(game, rating); // Player 2 loses

                    // Show game results
                    Console.WriteLine("\nGame Results:");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("| Player       | Opponent      | Result | Rating  |");
                    Console.WriteLine("-------------------------------------------------");

                    // Results for Player 1
                    Console.WriteLine($"| {player1.UserName,-12} | {player2.UserName,-12} | Win    | {rating,-8} |");

                    // Results for Player 2
                    Console.WriteLine($"| {player2.UserName,-12} | {player1.UserName,-12} | Lose   | {rating,-8} |");

                    Console.WriteLine("-------------------------------------------------");
                    break;


                case "3":
                    Console.WriteLine("Available players:");
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {players[i].UserName}");
                    }

                    Console.Write("Enter player number: ");
                    int statsIndex = int.Parse(Console.ReadLine()) - 1;

                    if (statsIndex >= 0 && statsIndex < players.Count)
                    {
                        players[statsIndex].ShowStats();  // This will now call the ShowStats method correctly
                    }
                    else
                    {
                        Console.WriteLine("Invalid player number.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}