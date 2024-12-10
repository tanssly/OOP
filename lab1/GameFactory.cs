namespace lab1
{
    public static class GameFactory
    {
        public static Game CreateGames(int gameType, GameAccount player1, GameAccount player2)
        {
            string player1Name = player1.UserName;
            string player2Name = player2.UserName;

            Game game = gameType switch
            {
                1 => new StandardGame(player1Name, player2Name),
                2 => new TrainingGame(player1Name, player2Name),
                3 => new SoloGame(player1Name, null),
                _ => throw new ArgumentException("Invalid game type.")
            };
            return game;
        }
    }
}