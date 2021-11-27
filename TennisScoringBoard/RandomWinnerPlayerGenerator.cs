using System;

namespace TennisScoring
{
    public class RandomWinnerPlayerGenerator : IRandomWinnerPlayerGenerator
    {
        public int GetPlayerNameWithPoint()
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
    }
}

