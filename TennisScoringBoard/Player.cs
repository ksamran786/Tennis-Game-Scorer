namespace TennisScoring
{
    public class Player : IPlayer
    {
        public int PointsPerGame { get; set; }
        public int GamesPerSet { get; set; }

        public string Name { get; set; }

        public int GetPointsPerGame()
        {
            return PointsPerGame;
        }

        public int GetSetScore()
        {
            return GamesPerSet;
        }

    }
}

