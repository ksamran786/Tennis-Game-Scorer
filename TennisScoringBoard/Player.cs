namespace TennisScoring
{
    /// <summary>
    /// Player information class
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Points won by player per game
        /// </summary>
        public int PointsPerGame { get; set; }

        /// <summary>
        /// NUmber of sets won by player in the match
        /// </summary>
        public int GamesPerSet { get; set; }

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get points information about the player
        /// </summary>
        /// <returns>Points won by player per game</returns>
        public int GetPointsPerGame()
        {
            return PointsPerGame;
        }

        /// <summary>
        /// Get sets information about the player
        /// </summary>
        /// <returns>Sets won by player per match</returns>
        public int GetSetScore()
        {
            return GamesPerSet;
        }

    }
}

