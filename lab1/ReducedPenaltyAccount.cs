public class ReducedPenaltyAccount : GameAccount
{
    private const double penaltyReductionFactor = 0.5; // Зниження штрафу на 50%

    public ReducedPenaltyAccount(string userName) : base(userName) { }

    public override void CalculatePoints(string result, int rating)
    {
        if (result == "Win")
        {
            CurrentRating += rating; // Стандартне збільшення рейтингу для перемоги
            Console.WriteLine($"Win: CurrentRating = {CurrentRating}");
        }
        else
        {
            int penalty = (int)(rating * penaltyReductionFactor); // Зменшений штраф
            CurrentRating -= penalty; // Зменшений штраф за програш
            Console.WriteLine($"Loss: Penalty = {penalty}, CurrentRating = {CurrentRating}");
        }

        CurrentRating = Math.Max(CurrentRating, 0); // Перевірка на негативний рейтинг
    }
}
