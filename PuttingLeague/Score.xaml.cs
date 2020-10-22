using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : UserControl, INotifyPropertyChanged
    {

        public Score()
        {
            InitializeComponent();
            this.DataContext = this;
            ResetColours();
        }

        public event EventHandler ScoreChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private SolidColorBrush _putts0Backgroud;
        public SolidColorBrush Putts0Background
        {
            get 
            { 
                return _putts0Backgroud;
            }
            set 
            { 
                _putts0Backgroud = value;
                this.OnPropertyChanged("Putts0Background");
            }
        }

        private SolidColorBrush _putts1Backgroud;
        public SolidColorBrush Putts1Background
        {
            get
            {
                return _putts1Backgroud;
            }
            set
            {
                _putts1Backgroud = value;
                this.OnPropertyChanged("Putts1Background");
            }
        }

        private SolidColorBrush _putts2Backgroud;
        public SolidColorBrush Putts2Background
        {
            get
            {
                return _putts2Backgroud;
            }
            set
            {
                _putts2Backgroud = value;
                this.OnPropertyChanged("Putts2Background");
            }
        }

        public int ScoreValue { get; set; }


        private void Putts_Click(object sender, RoutedEventArgs e)
        {
            ResetColours();
            var selectedColour = new SolidColorBrush(Colors.LightGreen);
            var toggle = sender as ToggleButton;

            if (toggle.IsChecked == true)
            {
                switch (toggle.Name)
                {
                    case "Putts0":
                        Putts0Background = selectedColour;
                        Putts1.IsChecked = false;
                        Putts2.IsChecked = false;
                        this.ScoreValue = 0;
                        break;

                    case "Putts1":
                        Putts1Background = selectedColour;
                        Putts0.IsChecked = false;
                        Putts2.IsChecked = false;
                        this.ScoreValue = 1;
                        break;

                    case "Putts2":
                        Putts2Background = selectedColour;
                        Putts1.IsChecked = false;
                        Putts0.IsChecked = false;
                        this.ScoreValue = 3;
                        break;
                }
            }
            else
            {
                this.ScoreValue = 0;
            }

            ScoreLabel.Content = $"Score: {this.ScoreValue}";

            this.ScoreChanged?.Invoke(this, new EventArgs());
        }

        private void ResetColours()
        {
            var colour = new SolidColorBrush(Colors.AliceBlue);
            Putts0Background = colour;
            Putts1Background = colour;
            Putts2Background = colour;
        }
    }
}
