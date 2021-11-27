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
        IPlayer player1, player2;


        ITennisGame _game;

        int serves = 0;
        public MainWindow()
        {
            InitializeComponent();

            player1 = new Player();
            player2 = new Player();

            player1.Name = "Roger";
            player2.Name = "Nadal";

            _game = new TennisGame(player1, player2, new GameScorer());


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintCurrentSetScore();
            PrintGameCurrentScore();


            _game.StartGame();
        }


        private void PrintCurrentSetScore()
        {
            string scoreMessage = $"Set: {player1.Name}/{player2.Name} \n {player1.GetSetScore()}/{player2.GetSetScore()}";
            Console.WriteLine(scoreMessage + "\n");

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void PrintGameCurrentScore()
        {
            if (player1.GetPointsPerGame() == (int)PointsTable.Forty && player2.GetPointsPerGame() == (int)PointsTable.Forty)
            {
                Console.WriteLine("DEUCE!");
            }
            else if (player1.GetPointsPerGame() == (int)PointsTable.Advantage)
            {
                Console.WriteLine($"ADVANTAGE {player1.Name}!");
            }
            else if (player2.GetPointsPerGame() == (int)PointsTable.Advantage)
            {
                Console.WriteLine($"ADVANTAGE {player2.Name}!");
            }

            string scoreMessage = $"{player1.Name} - {player1.GetPointsPerGame()}\n{player2.Name} - {player2.GetPointsPerGame()}";
            Console.WriteLine(scoreMessage);
        }
    }
}
