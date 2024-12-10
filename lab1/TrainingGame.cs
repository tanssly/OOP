namespace lab1
{
    public class TrainingGame(string player1Name, string player2Name) : Game(player1Name, player2Name)
    {
        protected internal override int ImitationGame(GameAccount player1, GameAccount player2)
        {
            int result = new Random().Next(0, 2);
            if (result == 0)
            {
                player1.WinGame(0);
                player2.LoseGame(0);
            }
            else
            {
                player2.WinGame(0);
                player1.LoseGame(0);
            }

            return result;
        }
    }
}