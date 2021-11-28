using System;

namespace TennisScoring
{
    public class TennisGame : ITennisGame
    {
        private readonly IPlayer _player1, _player2;
        private readonly IGameScorer _gameScoreManager;
        IRandomWinnerPlayerGenerator _randomPointWinnerPlayer;


        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="player1">Player</param>
        /// <param name="player2">Player</param>
        public TennisGame(IPlayer player1, IPlayer player2, IGameScorer scoreManager)
        {
            if (player1 == null || player2 == null)
            {
                throw new InvalidOperationException("player null exceptions.");

            }
            _player1 = player1;
            _player2 = player2;

            if (scoreManager == null)
            {
                throw new InvalidOperationException("Score Manager Null Error");

            }

            _gameScoreManager = scoreManager;

            _randomPointWinnerPlayer = new RandomWinnerPlayerGenerator();

        }

        /// <summary>
        /// BY calling this function the winner is declared.
        /// </summary>
        public void StartGame()
        {
            if (_randomPointWinnerPlayer == null)
            {
                throw new InvalidOperationException("Random generator Null Error");

            }
            int WinnerPlayer = _randomPointWinnerPlayer.GetPlayerNameWithPoint();
            PointWinner(WinnerPlayer);


        }

        /// <summary>
        /// Update the points table for the winner
        /// </summary>
        /// <param name="WinnerPlayer">The player who won the point</param>
        public void PointWinner(int WinnerPlayer)
        {
            _gameScoreManager.UpdateGameScore(WinnerPlayer, _player1, _player2);

            // Update Set points
            _gameScoreManager.UpdateSetScores(_player1, _player2);
        }
    }
}

