namespace TennisScoring
{
    public interface IRandomWinnerPlayerGenerator
    {
        int GetPlayerNameWithPoint(IPlayer player1, IPlayer player2);
    }
}