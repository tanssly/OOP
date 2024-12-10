namespace lab1
{
    public class SoloGame(string player1Name, string player2Name) : Game(player1Name, null)

    {
        protected internal override int ImitationGame(GameAccount player1, GameAccount _)
        {
            int result = new Random().Next(0, 2);

            if (result == 1)
            {
                player1.WinGame(10);
                Console.WriteLine($"{player1.UserName} виграв гру!");

            }
            else
            {
                player1.LoseGame(5); // Програш знімає 5 балів
                Console.WriteLine($"{player1.UserName} програв гру.");
            }

            return result;
        }
    }
}