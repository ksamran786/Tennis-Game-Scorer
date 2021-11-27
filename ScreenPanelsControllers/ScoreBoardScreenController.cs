using System;
using System.Windows;
using System.Windows.Controls;
using TennisScoring;

public class ScoreBoardScreenController : IScoreBoardScreenController
{
    private readonly IPlayer _player1, _player2;
    private readonly ITennisGame _gameManager;

    /// <summary>
    /// Button used to get random winner
    /// </summary>
    protected Button _playGameButton;

    /// <summary>
    /// Text elements used to show scores
    /// </summary>
    protected TextBlock _player1PointsScoreText, _player2PointsScoreText, _gamesScoreText;

    public ScoreBoardScreenController(IPlayer player1, IPlayer player2, ITennisGame gameManager, Button playGameButton, TextBlock player2PointsScoreText, TextBlock player1PointsScoreText, TextBlock gamesScoreText)
    {
        _player1 = player1;
        _player2 = player2;
        _gameManager = gameManager;

        _playGameButton = playGameButton;
        _player1PointsScoreText = player1PointsScoreText;
        _player2PointsScoreText = player2PointsScoreText;
        _gamesScoreText = gamesScoreText;

        _gamesScoreText.Text = "0 / 0";
        _player1.PointsPerGame = 0;
        _player2.PointsPerGame = 0;
        _player1PointsScoreText.Text = PointsConversion(_player1.GetPointsPerGame());
        _player2PointsScoreText.Text = PointsConversion(_player2.GetPointsPerGame());

        //Initialize listner
        _playGameButton.Click += PlayScreenButton_Click;

    }

    /// <summary>
    /// Play Game button is clicked
    /// </summary>
    protected void PlayScreenButton_Click(object sender, RoutedEventArgs e)
    {
        PrintCurrentSetScore();
        PrintGameCurrentScore();


        _gameManager.StartGame();
    }


    protected void PrintCurrentSetScore()
    {
        string scoreMessage = $"{_player1.GetSetScore()} / {_player2.GetSetScore()}";
        _gamesScoreText.Text = scoreMessage;

    }

    protected void PrintGameCurrentScore()
    {
        _player1PointsScoreText.Text = PointsConversion(_player1.GetPointsPerGame());
        _player2PointsScoreText.Text = PointsConversion(_player2.GetPointsPerGame());
    }

    /// <summary>
    /// Return the points according to the game format
    /// </summary>
    protected string PointsConversion(int point)
    {
        string points = null;
        
        if(point == 0) points = "0";
        else if(point == 1) points = "15";
        else if(point == 2) points = "30";
        else if (point == 3) points = "40";
        else if (point == 4) points = "ADV";



        return points;
    }

}
