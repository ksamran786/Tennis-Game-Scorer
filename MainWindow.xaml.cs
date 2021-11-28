using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisScoring;

namespace TennisGameScorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Player object
        /// </summary>
        private IPlayer _player1, _player2;

        /// <summary>
        /// Score Screen UI Controller
        /// </summary>
        private IScoreBoardScreenController _scoreScreenController;


        /// <summary>
        /// Referee Screen UI Controller
        /// </summary>
        private IRefereePanelController _refereePanelController;

        /// <summary>
        /// Tennis Game logic
        /// </summary>
        ITennisGame _game;

        public MainWindow()
        {
            InitializeComponent();
            _player1 = new Player();
            _player2 = new Player();
              
            _player1.Name = "Roger";
            _player2.Name = "Nadal";

            _game = new TennisGame(_player1, _player2, new GameScorer());

            _scoreScreenController = new ScoreBoardScreenController(_player1, _player2, _game, PlayGameButton, Player1Name, Player2Name, Player1PointsText, Player2PointsText,GamesPointText);

            _refereePanelController = new RefereePanelController(_player1, _player2, _game,_scoreScreenController, 
                                                                 Player1WinnerButton, Player2WinnerButton, ResumeMatchButton,MatchAbandonedButton,
                                                                 Player1InputField,Player2InputField,
                                                                 oneSets,TwoThreeSets,ThreeFiveSets);

            RegisterListeners();
        }


        /// <summary>
        /// Register Listners for each Button
        /// </summary>
        protected void RegisterListeners()
        {
            ScoreScreenButton.Click += ScoreScreenButton_Click;
            RefereeScreenButton.Click += RefereeScreenButton_Click;

        }

        /// <summary>
        /// Score board screen button is clicked
        /// </summary>
        private void ScoreScreenButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoardCanvas.Visibility = Visibility.Visible;
            RefereeScreenCanvas.Visibility = Visibility.Hidden;
            _scoreScreenController.OnEnable();
        }

        /// <summary>
        /// Referee screen button is clicked
        /// </summary>
        private void RefereeScreenButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreBoardCanvas.Visibility = Visibility.Hidden;
            RefereeScreenCanvas.Visibility = Visibility.Visible;
            _refereePanelController.OnEnable();


        }

    }
}
