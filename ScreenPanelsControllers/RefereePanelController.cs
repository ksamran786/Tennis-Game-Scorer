using System;
using System.Windows;
using System.Windows.Controls;
using TennisScoring;

class RefereePanelController : IRefereePanelController
{
    private readonly IPlayer _player1, _player2;
    private readonly ITennisGame _gameManager;
    private readonly IScoreBoardScreenController _scoreBoardScreenController;

    Button _player1WinButton, _player2WinButton, _matchResumeButton, _matchAbondendedButton, _scoreBoardScreenButton, _refereePanelButton;

    TextBox _player1NameTextBox, _player2NameTextBox;

    RadioButton _oneSetRadioButton, _twoThreeSetsRadioButton, _threeFiveSetsRadioButton;


    Canvas _infoCanvas;

    public RefereePanelController(IPlayer player1, IPlayer player2, ITennisGame gameManager, IScoreBoardScreenController scoreBoardScreenController,
                                    Button player1WinButton, Button player2WinButton, Button matchResumeButton, Button matchAbondendedButton, Button scoreBoardScreenButton, Button refereePanelButton,
                                    TextBox player1NameTextBox, TextBox player2NameTextBox,
                                    RadioButton oneSetRadioButton, RadioButton twoThreeSetsRadioButton,RadioButton threeFiveSetsRadioButton,
                                    Canvas infoCanvas)
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
        _scoreBoardScreenButton = scoreBoardScreenButton;
        _refereePanelButton = refereePanelButton;

        //TextBox
        _player1NameTextBox = player1NameTextBox;
        _player2NameTextBox = player2NameTextBox;

        _player1NameTextBox.Text = _player1.Name;
        _player2NameTextBox.Text = _player2.Name;

        //Canvas
        _infoCanvas = infoCanvas;

        // Radio Buttons
        _oneSetRadioButton = oneSetRadioButton;
        _twoThreeSetsRadioButton = twoThreeSetsRadioButton;
        _threeFiveSetsRadioButton = threeFiveSetsRadioButton;
       
        InitializeListners();
    }


    public void OnEnable()
    {
        _player1NameTextBox.Text = _player1.Name;
        _player2NameTextBox.Text = _player2.Name;
    }

    protected void InitializeListners()
    {
        //Initialize listner
        _player1NameTextBox.TextChanged += Player1NameChanged;
        _player2NameTextBox.TextChanged += Player2NameChanged;

        _player1WinButton.Click += Player1PointWinner;
        _player2WinButton.Click += Player2PointWinner;

        _matchAbondendedButton.Click += MatchAbondended;
        _matchResumeButton.Click += ResumeMatch;
    }
    protected void ResumeMatch(object sender, RoutedEventArgs e)
    {
        _scoreBoardScreenButton.Visibility = Visibility.Visible;
        _refereePanelButton.Visibility = Visibility.Visible;

        _infoCanvas.Visibility = Visibility.Hidden;
        _scoreBoardScreenButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
    }

    protected void MatchAbondended(object sender, RoutedEventArgs e)
    {
        _scoreBoardScreenButton.Visibility = Visibility.Hidden;
        _refereePanelButton.Visibility = Visibility.Hidden;

        _infoCanvas.Visibility = Visibility .Visible;
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

