using System;
using System.Windows;
using System.Windows.Controls;
using TennisScoring;

class RefereePanelController : IRefereePanelController
{
    private readonly IPlayer _player1, _player2;
    private readonly ITennisGame _gameManager;
    private readonly IScoreBoardScreenController _scoreBoardScreenController;

    Button _player1WinButton, _player2WinButton, _matchResumeButton, _matchAbondendedButton;

    TextBox _player1NameTextBox, _player2NameTextBox;

    RadioButton _oneSetRadioButton, _twoThreeSetsRadioButton, _threeFiveSetsRadioButton;


    public RefereePanelController(IPlayer player1, IPlayer player2, ITennisGame gameManager, IScoreBoardScreenController scoreBoardScreenController,
                                    Button player1WinButton, Button player2WinButton, Button matchResumeButton, Button matchAbondendedButton,
                                    TextBox player1NameTextBox, TextBox player2NameTextBox,
                                    RadioButton oneSetRadioButton, RadioButton twoThreeSetsRadioButton,RadioButton threeFiveSetsRadioButton)
    {
        _player1 = player1;
        _player2 = player2;


        _gameManager = gameManager;
        _scoreBoardScreenController = scoreBoardScreenController;

        //BUttons 
        _player1WinButton = player1WinButton;
        _player2WinButton = player2WinButton;
        _matchAbondendedButton = matchAbondendedButton;
        _matchResumeButton = matchResumeButton;

        //TextBox
        _player1NameTextBox = player1NameTextBox;
        _player2NameTextBox = player2NameTextBox;

        _player1NameTextBox.Text = _player1.Name;
        _player2NameTextBox.Text = _player2.Name;

        // Radio Buttons
        _oneSetRadioButton = oneSetRadioButton;
        _twoThreeSetsRadioButton = twoThreeSetsRadioButton;
        _threeFiveSetsRadioButton = threeFiveSetsRadioButton;
       
        InitializeListners();
    }

    protected void InitializeListners()
    {
        //Initialize listner
        _player1NameTextBox.TextChanged += Player1NameChanged;
        _player2NameTextBox.TextChanged += Player2NameChanged;

        _player1WinButton.Click += Player1PointWinner;
        _player2WinButton.Click += Player2PointWinner;
    }


    public void OnEnable()
    {
        _player1NameTextBox.Text = _player1.Name;
        _player2NameTextBox.Text = _player2.Name;
    }

    protected void Player1NameChanged(object Sender, TextChangedEventArgs e)
    {
        _player1.Name = _player1NameTextBox.Text;
    }

    protected void Player2NameChanged(object sender, TextChangedEventArgs e)
    {
        _player2.Name = _player2NameTextBox.Text;
    }

    protected void Player2PointWinner(object sender, RoutedEventArgs e)
    {
        _player2.PointsPerGame++;
    }

    protected void Player1PointWinner(object sender, RoutedEventArgs e)
    {
        _player1.PointsPerGame++;

    }
}

