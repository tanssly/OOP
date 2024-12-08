public class VictoryStreakAccount : GameAccount
{
    private int winStreak = 3;

    public VictoryStreakAccount(string userName) : base(userName) { }

    
    public override void CalculatePoints(string result, int rating)
    {
        if (result == "Win")
        {
            winStreak++; // Збільшуємо серію перемог
            CurrentRating += rating + (winStreak * 10); // Додаємо бонус за серію перемог
            Console.WriteLine($"Win streak: {winStreak}, Rating after win: {CurrentRating}");
        }
        else
        {
            winStreak = 0; 
            CurrentRating -= rating; 
            Console.WriteLine($"Win streak reset to 0, Rating after loss: {CurrentRating}");
        }

        CurrentRating = Math.Max(CurrentRating, 0); // Перевірка на негативний рейтинг
    }
}
