namespace lab1
{
    public class StandardGame(string player1Name, string player2Name) : Game(player1Name, player2Name)

    {
        protected internal override int ImitationGame(GameAccount player1, GameAccount player2)
        {
            int result = new Random().Next(0, 2);

            if (result == 0)
            {
                player1.WinGame(5);
                player2.LoseGame(5);

            }
            else
            {
                player2.WinGame(5);
                player1.LoseGame(5);
            }

            return result;
        }
    }
}