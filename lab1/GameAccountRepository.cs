namespace lab1;

public class GameAccountRepository(DbContext dbContext) : IGameAccountRepository
{
    private DbContext DbContext { get; } = dbContext;

    public void Create(GameAccount account)
    {
        if (DbContext.Players.Any(p => p.UserName == account.UserName))
        {
            throw new ArgumentException("A player with that name already exists. Please enter a unique name.");
        }
        DbContext.Players.Add(account);
    }

    public List<GameAccount> ReadAll()
    {
        return DbContext.Players;
    }

    public GameAccount ReadById(int id)
    {
        var account = DbContext.Players.FirstOrDefault(p => p.Id == id);
        return account;
    }
    public GameAccount ReadByUserName(string userName)
    {
        return DbContext.Players.FirstOrDefault(acc => acc.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
    }

    public void Update(GameAccount updatedAccount)
    {
        var account = DbContext.Players.FirstOrDefault(a => a.Id == updatedAccount.Id);

        if (account != null)
        {
            account.UserName = updatedAccount.UserName;
        }
        else
        {
            throw new ArgumentException("Account not found.");
        }
    }

    public void Delete(int id)
    {
        var account = DbContext.Players.FirstOrDefault(p => p.Id == id);
        if (account != null)
        {
            DbContext.Players.Remove(account);
        }
        else
        {
            throw new ArgumentException("Account not found.");
        }
    }
}