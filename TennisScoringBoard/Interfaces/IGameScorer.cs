namespace TennisScoring
{
    public interface IGameScorer
    {
        void UpdateGameScore(int playerWon, IPlayer player1, IPlayer player2);
        void UpdateSetScores( IPlayer player1, IPlayer player2);
    }
}