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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string turn = "Player 1";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            selectednotempty_label.Visibility = Visibility.Hidden;
            MessageBox.Show("Player 1 Symbol is X\nPlayer 2 Symbol is O", "Here are some Rules:", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            //MessageBox.Show("Do you want to Play VS AI?", "Select One", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        }
        private void Box_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (((Image)sender).Source.ToString().EndsWith("circle.png") || ((Image)sender).Source.ToString().EndsWith("cross.png"))
            {
                case true:
                    {
                        selectednotempty_label.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    {
                        selectednotempty_label.Visibility = Visibility.Hidden;
                        switch (turn.EndsWith("1"))
                        {
                            case true:
                                {
                                    ((Image)sender).Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\cross.png", UriKind.Relative));
                                    break;
                                }
                            default:
                                {
                                    ((Image)sender).Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\circle.png", UriKind.Relative));
                                    break;
                                }
                        }
                        Check_Play(turn == "Player 1" ? "cross" : "circle");
                        turn_label.Content = "Turn: " + (turn = (turn == "Player 1") ? "Player 2" : "Player 1");
                        break;
                    }
            }

        }

        private void Check_Play(string currrent_played_by)
        {
            bool someonewon = false;
            switch ((Box_00.Source.ToString() == Box_10.Source.ToString()) && (Box_10.Source.ToString() == Box_20.Source.ToString()) && !(Box_00.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_00.Source = Box_10.Source = Box_20.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_horizontal.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_01.Source.ToString() == Box_11.Source.ToString()) && (Box_01.Source.ToString() == Box_21.Source.ToString()) && !(Box_01.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_01.Source = Box_11.Source = Box_21.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_horizontal.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_02.Source.ToString() == Box_12.Source.ToString()) && (Box_02.Source.ToString() == Box_22.Source.ToString()) && !(Box_02.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_01.Source = Box_11.Source = Box_21.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_horizontal.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_00.Source.ToString() == Box_01.Source.ToString()) && (Box_00.Source.ToString() == Box_02.Source.ToString()) && !(Box_00.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_00.Source = Box_01.Source = Box_02.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_vertical.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_10.Source.ToString() == Box_11.Source.ToString()) && (Box_10.Source.ToString() == Box_12.Source.ToString()) && !(Box_10.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_10.Source = Box_11.Source = Box_12.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_vertical.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_20.Source.ToString() == Box_21.Source.ToString()) && (Box_20.Source.ToString() == Box_22.Source.ToString()) && !(Box_20.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_20.Source = Box_21.Source = Box_22.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_vertical.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_00.Source.ToString() == Box_11.Source.ToString()) && (Box_00.Source.ToString() == Box_22.Source.ToString()) && !(Box_00.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_00.Source = Box_11.Source = Box_22.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_diagonal_left.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch ((Box_02.Source.ToString() == Box_11.Source.ToString()) && (Box_02.Source.ToString() == Box_20.Source.ToString()) && !(Box_02.Source.ToString().EndsWith("white.png")))
            {
                case true:
                    {
                        Box_02.Source = Box_11.Source = Box_20.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_diagonal_right.png", UriKind.Relative));
                    }
                    someonewon = true;
                    break;
            }
            switch (someonewon)
            {
                case true:
                    {
                        MessageBox.Show(turn + " Won this Match!", "Winner", MessageBoxButton.OK, MessageBoxImage.Information);
                        ((Label)FindName(currrent_played_by == "cross" ? "_1" : "_2")).Content = Convert.ToInt32(((Label)FindName(currrent_played_by == "cross" ? "_1" : "_2")).Content) + 1;
                        Button_Click_1(null, null);
                        break;
                    }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Box_12.Source = Box_10.Source = Box_11.Source = Box_20.Source = Box_22.Source = Box_21.Source = Box_02.Source = Box_01.Source = Box_00.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\white.png", UriKind.Relative));
        }
    }
}