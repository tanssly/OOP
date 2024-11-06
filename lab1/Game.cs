public class Game
{
    public int GameIndex { get; }
    public string OpponentName { get; }
    public string Result { get; }
    public int Rating { get; }

    // Конструктор
    public Game(int gameIndex, string opponentName, string result, int rating)
    {
        GameIndex = gameIndex;
        OpponentName = opponentName;
        Result = result;
        Rating = rating;
    }
}
