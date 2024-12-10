namespace lab1;

public class GameAccountServices(GameAccountRepository repository) : IGameAccountServices
{
    private GameAccountRepository Repository { get; set; } = repository;

    public List<GameAccount> ReadAll()
    {
        return Repository.ReadAll();
    }

    public GameAccount GetAccountById(int id)
    {
        var account = Repository.ReadById(id);
        if (account == null)
        {
            throw new ArgumentException("Account not found.");
        }
        return account;
    }
    public GameAccount GetAccountByUserName(string userName)
    {
        var account = Repository.ReadByUserName(userName);
        if (account == null)
        {
            throw new ArgumentException("Account not found.");
        }
        return account;
    }
    public void AddGameAccount(GameAccount gameAccount)
    {
        Repository.Create(gameAccount);
    }

    public void UpdateGameAccount(GameAccount account)
    {
        Repository.Update(account);
    }

    public void DeleteGameAccount(int id)
    {
        Repository.Delete(id);
    }
}