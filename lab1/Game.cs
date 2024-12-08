public abstract class Game
{
    public int GameIndex { get; private set; }
    public string OpponentName { get; private set; }
    public string Result { get; private set; }
    public int Rating { get; private set; }

    public Game(int gameIndex, string opponentName, string result, int rating)
    {
        GameIndex = gameIndex;
        OpponentName = opponentName;
        Result = result;
        Rating = rating;
    }

    // Абстрактний метод для розрахунку рейтингу
    public abstract int CalculateRating(int rating);

    // Метод для проведення гри
    public virtual void Play(GameAccount player, GameAccount opponent, int result)
    {
        if (result == 1)
        {
            player.WinGame(this, CalculateRating(Rating));
            opponent.LoseGame(this, CalculateRating(Rating));
        }
        else if (result == -1)
        {
            player.LoseGame(this, CalculateRating(Rating));
            opponent.WinGame(this, CalculateRating(Rating));
        }
    }
}
