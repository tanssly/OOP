public class TrainingGame : Game
{
    public TrainingGame(int gameIndex, string opponentName, string result)
        : base(gameIndex, opponentName, result, 0) { }

    public override int CalculateRating(int rating)
    {
        return 0; 
    }

    public override void Play(GameAccount player, GameAccount opponent, int result)
    {
        base.Play(player, opponent, result);
    }
}
