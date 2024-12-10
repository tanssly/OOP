namespace lab1;

public interface IGameAccountRepository
{
    void Create(GameAccount account);
    GameAccount ReadById(int id);
    List<GameAccount> ReadAll();
    void Update(GameAccount account);
    void Delete(int id);
}