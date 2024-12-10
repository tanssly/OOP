namespace lab1;

public interface IGameRepository
{
    void Create(GameHistory game);
    List<GameHistory> ReadAll();
    GameHistory ReadByIndex(int gameIndex);
    void Delete(int gameIndex);
    public void Update(GameHistory updatedGame);
}