namespace lab1
{
    public abstract class GameAccount(string userName, int id)
    {
        private int _currentRating = 1;
        public string UserName { get; set; } = userName;
        public int Id { get; protected set; } = id;
        private static int _globalId = 1;

        public static int GetNextId()
        {
            return _globalId++;
        }

        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = Math.Max(value, 1);
        }

        public abstract void WinGame(int rating);
        public abstract void LoseGame(int rating);

        public void GetStats(GameServices gameService)
        {
            Console.WriteLine($"\n=== Game History for {UserName} ===");
            Console.WriteLine($"{"Index",-6} | {"Opponent",-12} | {"Result",-6} | {"Rating",-6} | ");
            Console.WriteLine(new string('-', 55));

            var gamesForUser = gameService.ReadAll()
                .Where(game => game.AccountId == Id)
                .ToList();

            foreach (var game in gamesForUser)
            {
                string opponent = game.OpponentName;
                string result = game.Result;

                Console.WriteLine($"{game.GameIndex,-6} | {opponent,-12} | {result,-6} | {game.Rating,-6} | ");
            }

            Console.WriteLine("\nAccount type: " + (this is VictoryStreakAccount ? "VictoryStreak" : this is ReducedPenaltyAccount ? "Reduced Penalty" : "Standard"));
            Console.WriteLine("Current Rating: " + CurrentRating);
        }


    }
}