public class SoloGame : Game
{
    public SoloGame(int gameIndex, string opponentName, string result, int rating)
        : base(gameIndex, opponentName, result, rating) { }

    
    public override int CalculateRating(int rating)
    {
        return Rating / 2; // Solo game дає половину рейтингу
    }

    
    public override void Play(GameAccount player, GameAccount opponent, int result)
    {
        base.Play(player, null, result); // Для solo гри передаємо null
    }
}