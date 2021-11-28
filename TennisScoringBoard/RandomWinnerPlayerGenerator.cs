using System;

namespace TennisScoring
{
    public class RandomWinnerPlayerGenerator : IRandomWinnerPlayerGenerator
    {
        /// <summary>
        /// Declare randomly if the player1 or player2 won, e.g. 1 or 2
        /// </summary>
        /// <returns></returns>
        public int GetPlayerNameWithPoint()
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
    }
}

