public class StandardGame : Game
{
    public StandardGame(int gameIndex, string opponentName, string result, int rating)
        : base(gameIndex, opponentName, result, rating) { }

    public override int CalculateRating(int rating)
    {
        return Rating; // У стандартній грі рейтинг не змінюється
    }

    public override void Play(GameAccount player, GameAccount opponent, int result)
    {
        base.Play(player, opponent, result);
    }
}
