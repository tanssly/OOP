public abstract class GameAccount
{
    public string UserName { get; private set; }
    public int CurrentRating { get; protected set; }
    public int GamesCount => GameHistory.Count;

    private List<GameHistoryEntry> GameHistory = new List<GameHistoryEntry>();

    public GameAccount(string userName)
    {
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        CurrentRating = 1000;  
    }

    // Abstract method for calculating points
    public abstract void CalculatePoints(string result, int rating);

    // Win game
    public void WinGame(Game game, int rating)
    {
        CurrentRating += rating;
        GameHistory.Add(new GameHistoryEntry(game.GameIndex, game.OpponentName, "Win", rating));
    }

    // Lose game
    public void LoseGame(Game game, int rating)
    {
        CurrentRating -= rating;
        if (CurrentRating < 1)
        {
            CurrentRating = 1; // Minimum rating
        }
        GameHistory.Add(new GameHistoryEntry(game.GameIndex, game.OpponentName, "Lose", rating));
    }

    // Show stats
    public void ShowStats()
    {
        Console.WriteLine($"\nStats for {UserName}:");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("| Game Index | Opponent      | Result | Rating  |");
        Console.WriteLine("-------------------------------------------------");
        foreach (var entry in GameHistory)
        {
            Console.WriteLine($"| {entry.GameIndex,-11} | {entry.OpponentName,-12} | {entry.Result,-6} | {entry.Rating,-7} |");
        }
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"Current Rating: {CurrentRating}, Total Games Played: {GamesCount}");
    }
}
