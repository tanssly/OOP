namespace lab1
{
    public class GameHistory(string opponentName, string result, int rating, int gameIndex, int accountId)
    {
        public string OpponentName { get; internal set; } = opponentName;
        public string Result { get; internal set; } = result;
        public int Rating { get; internal set; } = rating;
        public int GameIndex { get; private set; } = gameIndex;
        public int AccountId { get; private set; } = accountId;
    }
}