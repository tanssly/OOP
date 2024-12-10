namespace lab1;

public class DbContext
{
    public List<GameAccount> Players { get; } = new();
    public List<GameHistory> Games { get; } = new();
}