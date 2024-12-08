public static class GameFactory
{
    public static Game CreateGame(string gameType, int gameIndex, string opponentName, string result, int rating)
    {
        return gameType switch
        {
            "Standard" => new StandardGame(gameIndex, opponentName, result, rating),
            "Training" => new TrainingGame(gameIndex, opponentName, result, rating),
            "Solo" => new SoloGame(gameIndex, opponentName, result, rating),
            _ => throw new ArgumentException("Invalid game type")
        };
    }
}
