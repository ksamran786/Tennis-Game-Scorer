using System;

namespace TennisScoring
{
    public class RandomWinnerPlayerGenerator : IRandomWinnerPlayerGenerator
    {
        public int GetPlayerNameWithPoint(IPlayer player1, IPlayer player2)
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
    }
}

