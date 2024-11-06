using System;
namespace lab1
{
    public class GameAccount
    {
        public string UserName { get; private set; }
        public int CurrentRating { get; private set; } = 1;
        public int GamesCount => GameHistory.Count;

        private List<GameHistoryEntry> GameHistory = new List<GameHistoryEntry>();

        public GameAccount(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public void WinGame(string opponentName, int rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentException("Rating must be positive.", nameof(rating));
            }

            CurrentRating += rating;
            GameHistory.Add(new GameHistoryEntry
            {
                GameIndex = GameHistory.Count + 1,
                OpponentName = opponentName,
                Result = "Win",
                Rating = rating
            });
        }

        public void LoseGame(string opponentName, int rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentException("Rating must be positive.", nameof(rating));
            }

            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GameHistory.Add(new GameHistoryEntry
            {
                GameIndex = GameHistory.Count + 1,
                OpponentName = opponentName,
                Result = "Lose",
                Rating = rating
            });
        }

        public void GetStats()
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

    public class GameHistoryEntry
    {
        public int GameIndex { get; set; }
        public string OpponentName { get; set; }
        public string Result { get; set; }
        public int Rating { get; set; }
    }
}
