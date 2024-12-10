using lab1;

public abstract class Game
{
    private static int _globalGameIndex;

    public static int GetNextGameIndex() => ++_globalGameIndex;

    public string Player1Name { get; set; }
    public string Player2Name { get; set; }

    protected Game(string player1Name, string player2Name)
    {
        Player1Name = player1Name;
        Player2Name = player2Name;
    }

    protected internal abstract int ImitationGame(GameAccount player1, GameAccount player2);
}
