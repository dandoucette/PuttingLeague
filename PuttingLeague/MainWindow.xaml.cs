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

namespace PuttingLeague
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Player1Round1.ScoreChanged += UpdateTotal;
            Player1Round2.ScoreChanged += UpdateTotal;
            Player1Round3.ScoreChanged += UpdateTotal;
            Player1Round4.ScoreChanged += UpdateTotal;
            Player1Round5.ScoreChanged += UpdateTotal;
            Player1Round6.ScoreChanged += UpdateTotal;
            Player1Round7.ScoreChanged += UpdateTotal;
            Player1Round8.ScoreChanged += UpdateTotal;

            Player2Round1.ScoreChanged += UpdateTotal;
            Player2Round2.ScoreChanged += UpdateTotal;
            Player2Round3.ScoreChanged += UpdateTotal;
            Player2Round4.ScoreChanged += UpdateTotal;
            Player2Round5.ScoreChanged += UpdateTotal;
            Player2Round6.ScoreChanged += UpdateTotal;
            Player2Round7.ScoreChanged += UpdateTotal;
            Player2Round8.ScoreChanged += UpdateTotal;
        }

        private void UpdateTotal(object sender, EventArgs e)
        {
            int player1Score = 0;
            int player1PuttsMade = 0;
            TallyScore(Player1Round1, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round2, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round3, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round4, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round5, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round6, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round7, ref player1Score, ref player1PuttsMade);
            TallyScore(Player1Round8, ref player1Score, ref player1PuttsMade);

            Player1Total.Text = player1Score.ToString();

            int player2Score = 0;
            int player2PuttsMade = 0;
            TallyScore(Player2Round1, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round2, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round3, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round4, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round5, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round6, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round7, ref player2Score, ref player2PuttsMade);
            TallyScore(Player2Round8, ref player2Score, ref player2PuttsMade);

            Player2Total.Text = player2Score.ToString();

            UpdateStats(player1PuttsMade, player2PuttsMade);
        }

        private void TallyScore(Score scoreControl, ref int score, ref int puttsMade)
        {
            score += scoreControl.ScoreValue;
            puttsMade += scoreControl.ScoreValue == 3 ? 2 : scoreControl.ScoreValue;
        }

        private void UpdateStats(int player1PuttsMade, int player2PuttsMade)
        {
            int precision = 2;
            decimal player1Stat = CalculateStat(player1PuttsMade);
            Player1StatsThisRoundTextBlock.Text = $"{Math.Round(player1Stat, precision)} %";

            decimal player2Stat = CalculateStat(player2PuttsMade);
            Player2StatsThisRoundTextBlock.Text = $"{Math.Round(player2Stat, precision)} %";
        }

        private decimal CalculateStat(int puttsMade)
        {
            decimal putts = decimal.Parse(puttsMade.ToString());
            return (putts / 16M) * 100M;
        }
    }
}
