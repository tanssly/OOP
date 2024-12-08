public class StandardAccount : GameAccount
{
    public StandardAccount(string userName) : base(userName) { }

    
    public override void CalculatePoints(string result, int rating)
    {
        if (result == "Win")
        {
            CurrentRating += rating; 
        }
        else if (result == "Lose")
        {
            CurrentRating -= rating; 
        }
        CurrentRating = Math.Max(CurrentRating, 0); 
    }
}
