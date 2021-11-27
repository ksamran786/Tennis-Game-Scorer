using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TennisScoring;

namespace TennisGameTets
{
    [TestClass]
    public class GameScorerTests
    {
        [TestMethod]
        public void UpdateGameScore_Player1Won_Player1GameScoreIsEqualToOne()
        {
            //Arrange
            IPlayer player1 = new Player();
            IPlayer player2 = new Player();
            IGameScorer gameScorer = new GameScorer();

            // Act
            gameScorer.UpdateGameScore(1,player1,player2);

            //Assert
            Assert.AreEqual(1, player1.GetPointsPerGame());
        }
        [TestMethod]
        public void UpdateGameScore_Player2Won_Player2GameScoreIsEqualToOne()
        {
            //Arrange
            IPlayer player1 = new Player();
            IPlayer player2 = new Player();
            IGameScorer gameScorer = new GameScorer();

            // Act
            gameScorer.UpdateGameScore(2, player1, player2);

            //Assert
            Assert.AreEqual(1, player2.GetPointsPerGame());

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Server out of course. Again serve")]
        public void UpdateGameScore_NoPlayerWon_ExceptionOccurs()
        {
            //Arrange
            IPlayer player1 = new Player();
            IPlayer player2 = new Player();
            IGameScorer gameScorer = new GameScorer();

            // Act
            gameScorer.UpdateGameScore(3, player1, player2);


        }
    }
}
