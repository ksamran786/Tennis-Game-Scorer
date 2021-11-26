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
        internal TennisGame(IPlayer player1, IPlayer player2, IGameScorer scoreManager)
        {
            if (player1 == null || player2 == null)
            {
                Console.WriteLine("Players cannot be null");
                return;
            }
            _player1 = player1;
            _player2 = player2;

            if (scoreManager == null)
            {
                Console.WriteLine("Score manager cannot be null");
                return;
            }

            _gameScoreManager = scoreManager;

            _randomPointWinnerPlayer = new RandomWinnerPlayerGenerator();

        }

        public void StartGame()
        {
            if (_randomPointWinnerPlayer == null)
            {
                Console.WriteLine("Null Error");
                return;
            }
            int WinnerPlayer = _randomPointWinnerPlayer.GetPlayerNameWithPoint(_player1, _player2);
            _gameScoreManager.UpdateGameScore(WinnerPlayer, _player1, _player2);

            // Update Set points
            _gameScoreManager.UpdateSetScores(_player1,_player2);

        }
        public void QuitGame()
        {
            throw new System.NotImplementedException();
        }

    }
}

