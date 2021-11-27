using System;

namespace TennisScoring
{

    public enum PointsTable
    {
        Love = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Advantage = 4,
        Game = 5,
        Duce = 6
    }
    public class GameScorer : IGameScorer
    {

        public void UpdateGameScore(int playerWon, IPlayer player1, IPlayer player2)
        {
            // Player1 won the point
            if (playerWon == 1)
            {
                if (player1.GetPointsPerGame() >= (int)PointsTable.Forty &&
                     player1.GetPointsPerGame() ==  player2.GetPointsPerGame() +2)
                {
                    player1.PointsPerGame = (int)PointsTable.Game;
                    return;
                }

                if (player2.GetPointsPerGame() == (int)PointsTable.Advantage)
                {
                    // Duce
                    player2.PointsPerGame--;
                }
                else
                {
                    //Point gain
                    player1.PointsPerGame++;
                }
            }
            else if (playerWon == 2) // Player Second won
            {
                if (player2.GetPointsPerGame() >= (int)PointsTable.Forty &&
                     player2.GetPointsPerGame() == player1.GetPointsPerGame() + 2)
                {
                    player2.PointsPerGame = (int)PointsTable.Game;
                    return;
                }

                if (player1.GetPointsPerGame() == (int)PointsTable.Advantage)
                {
                    // Duce
                    player1.PointsPerGame--;
                }
                else
                {
                    //Point gain
                    player2.PointsPerGame++;
                }
            }
            else
            {
                throw new InvalidOperationException("Server out of course. Again serve");
            }
        }

        public void UpdateSetScores( IPlayer player1, IPlayer player2)
        {
            if(player1.GetPointsPerGame() == (int) PointsTable.Game)
            {
                player1.PointsPerGame = 0;
                player2.PointsPerGame = 0;
                player1.GamesPerSet++;
            }
            else if (player2.GetPointsPerGame() == (int)PointsTable.Game)
            {
                player1.PointsPerGame = 0;
                player2.PointsPerGame = 0;
                player2.GamesPerSet++;
            }
        }
    }
}

