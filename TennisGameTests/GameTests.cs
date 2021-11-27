using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TennisScoring;
namespace TennisGameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "player null exceptions.")]
        public void TennisGame_NoPlayer1_ExceptionOccurs()
        {
            //Arrange
            IPlayer player1 = null;
            IPlayer player2 = new Player();
            IGameScorer gameScorer = new GameScorer();

            // Act
            ITennisGame game = new TennisGame(player1, player2, gameScorer);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "player null exceptions.")]
        public void TennisGame_NoPlayer2_ExceptionOccurs()
        {
            //Arrange
            IPlayer player1 = new Player();
            IPlayer player2 = null;
            IGameScorer gameScorer = new GameScorer();

            // Act
            ITennisGame game = new TennisGame(player1, player2, gameScorer);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Score Manager Null Error")]
        public void TennisGame_ScoreManagerIsNull_ExceptionOccurs()
        {
            //Arrange
            IPlayer player1 = new Player();
            IPlayer player2 = new Player(); ;
            IGameScorer gameScorer = null;

            // Act
            ITennisGame game = new TennisGame(player1, player2, gameScorer);

        }
    }
}
