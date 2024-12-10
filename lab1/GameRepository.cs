namespace lab1;

public class GameRepository(DbContext dbContext) : IGameRepository
{
    private DbContext DbContext { get; set; } = dbContext;

    public void Create(GameHistory game)
    {
        DbContext.Games.Add(game);
    }

    public List<GameHistory> ReadAll()
    {
        return DbContext.Games.Count == 0 ? null : DbContext.Games;
    }

    public GameHistory ReadByIndex(int gameIndex)
    {
        return DbContext.Games.FirstOrDefault(g => g.GameIndex.Equals(gameIndex));
    }

    public void Update(GameHistory updatedGame)
    {
        var game = DbContext.Games.FirstOrDefault(g => g.GameIndex == updatedGame.GameIndex);
        if (game != null)
        {
            game.OpponentName = updatedGame.OpponentName;
            game.Result = updatedGame.Result;
            game.Rating = updatedGame.Rating;
        }
        else
        {
            throw new ArgumentException("Game not found.");
        }
    }

    public void Delete(int gameIndex)
    {
        var games = ReadAll();
        var game = games.FirstOrDefault();

        if (game != null)
        {
            DbContext.Games.Remove(game);
        }
        else
        {
            throw new ArgumentException("Game not found.");
        }
    }
}