public class GameHistoryEntry
{
    public int GameIndex { get; private set; }
    public string OpponentName { get; private set; }
    public string Result { get; private set; }
    public int Rating { get; private set; }

    public GameHistoryEntry(int gameIndex, string opponentName, string result, int rating)
    {
        GameIndex = gameIndex;
        OpponentName = opponentName;
        Result = result;
        Rating = rating;
    }
}