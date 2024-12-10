
namespace lab1
{
    public class GameServices(GameRepository repository) : IGameServices
    {
        private GameRepository Repository { get; set; } = repository;

        public void Create(GameHistory game)
        {
            Repository.Create(game);
        }

        public List<GameHistory> ReadAll()
        {
            return Repository.ReadAll();
        }

        public GameHistory ReadByIndex(int gameIndex)
        {
            return Repository.ReadByIndex(gameIndex);
        }


        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public void Update(GameHistory updatedGame)
        {
            Repository.Update(updatedGame);
        }

        public void PlayGame(GameServices gameServices, int numberOfGames, Game game, GameAccount player1, GameAccount player2)
        {
            string player1Name = player1.UserName;
            string player2Name = player2.UserName;
            Console.WriteLine("\nStarting games ...");
            for (int i = 0; i < numberOfGames; i++)
            {
                int gameIndex = Game.GetNextGameIndex();
                int result = game.ImitationGame(player1, player2);
                GameHistory gameHist1;
                GameHistory gameHist2;
                if (result == 0)
                {
                    string resultGame1 = "Win";
                    string resultGame2 = "Lose";
                    gameHist1 = new GameHistory(player1Name, resultGame1, player1.CurrentRating, gameIndex, player1.Id);
                    gameHist2 = new GameHistory(player2Name, resultGame2, player2.CurrentRating, gameIndex, player2.Id);
                }
                else
                {
                    string resultGame1 = "Lose";
                    string resultGame2 = "Win";
                    gameHist1 = new GameHistory(player1Name, resultGame1, player1.CurrentRating, gameIndex, player1.Id);
                    gameHist2 = new GameHistory(player2Name, resultGame2, player2.CurrentRating, gameIndex, player2.Id);
                }
                gameServices.Create(gameHist1);
                gameServices.Create(gameHist2);
            }
        }
    }
}