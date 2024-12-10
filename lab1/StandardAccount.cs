namespace lab1
{
    public class StandardAccount(string userName, int id) : GameAccount(userName, id)
    {
        public override void WinGame(int rating)
        {
            CurrentRating += rating;
        }

        public override void LoseGame(int rating)
        {
            CurrentRating -= rating;
        }
    }
}