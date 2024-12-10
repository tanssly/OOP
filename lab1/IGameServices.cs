namespace lab1;

public interface IGameServices
{
    void Create(GameHistory game);
    List<GameHistory> ReadAll();
    GameHistory ReadByIndex(int gameIndex);
    void Delete(int id);
    public void Update(GameHistory updatedGame);

    public void PlayGame(GameServices gameServices, int numberOfGames, Game game, GameAccount player1, GameAccount player2);
}