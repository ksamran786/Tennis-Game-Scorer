namespace TennisScoring
{
    public interface IPlayer
    {
        int GamesPerSet { get; set; }
        int PointsPerGame { get; set; }
        string  Name{ get; set; }

        int GetSetScore();
        int GetPointsPerGame();
    }
}