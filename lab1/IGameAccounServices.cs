namespace lab1;

public interface IGameAccountServices
{
    void AddGameAccount(GameAccount gameAccount);
    List<GameAccount> ReadAll();
    GameAccount GetAccountById(int id);
    void UpdateGameAccount(GameAccount gameAccount);
    void DeleteGameAccount(int id);
}