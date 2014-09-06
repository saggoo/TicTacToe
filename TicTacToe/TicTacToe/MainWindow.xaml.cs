using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string turn = "Player 1";
        bool vsai = true;
        Random randno=new Random();
        bool someonewon = false,notificationsenabled=true;
        short s_0, s_1,occupied_boxes=0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            selectednotempty_label.Visibility = Visibility.Hidden;
            // MessageBox.Show("Player 1 Symbol is X\nPlayer 2 Symbol is O", "Here are some Rules:", MessageBoxButton.OK,MessageBoxImage.Information,MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            vsai_changed();  
        }
        private void AI_Play()
        {
            s_0 = Convert.ToInt16(randno.Next(0, 3));
            s_1 = Convert.ToInt16(randno.Next(0,3));
            switch (((Image)boxes_grid.FindName("Box_" + s_0 + s_1)).Source.ToString().EndsWith("/white.png"))
            {
                case true:
                    {
                        ((Image)boxes_grid.FindName("Box_" + s_0 + s_1)).Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\circle.png", UriKind.Relative));
                        occupied_boxes++;
                        Check_Play("circle");
                        turn_label.Content="Turn of "+ (turn = "You");
                        break;
                    }
                default:
                    {
                        AI_Play();
                        break;
                    }
            }
        }
        private void vsai_changed()
        {
            switch (vsai)
            {
                case true:
                    {
                        turn_label.Content = "Turn of "+(turn="You");
                        player1name_label.Content = "You:";
                        player2name_label.Content = "Computer:";
                        rules_player1_label.Content = "Your Symbol is X";
                        rules_player2_label.Content = "Computer Symbol is O";
                        break;
                    }
                case false:
                    {
                        turn_label.Content = "Turn of "+(turn="Player 1");
                        player1name_label.Content = "Player 1:";
                        player2name_label.Content = "Player 2:";
                        rules_player1_label.Content = "Player 1 Symbol is X";
                        rules_player2_label.Content = "Player 2 Symbol is O";
                        break;
                    }
            }
            _1.Content = _2.Content = _3.Content = "0";
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
                        switch (turn=="Player 1" || turn=="You")
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
                        occupied_boxes++;
                        // position[++position_index] =Convert.ToInt16(((Image)sender).Name.TrimStart(new char[] { 'B', 'o', 'x', '_' }));
                        Check_Play((turn == "Player 1" || turn == "You") ? "cross" : "circle");
                        turn_label.Content = "Turn of " + (turn = (turn == "Player 1" || turn == "You") ? (vsai == true ? "Computer" : "Player 2") : (vsai == true ? "You" : "Player 1"));
                        switch (vsai)
                        {
                            case true:
                                {
                                    AI_Play();
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        private void Check_Play(string currrent_played_by)
        {
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
                        Box_02.Source = Box_12.Source = Box_22.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\" + currrent_played_by + "_horizontal.png", UriKind.Relative));
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
                        switch (notificationsenabled)
                        {
                            case true:
                                {
                                    MessageBox.Show(turn + " Won this Match!", "Winner", MessageBoxButton.OK, MessageBoxImage.Information);
                                    break;
                                }
                        } 
                        ((Label)FindName(currrent_played_by == "cross" ? "_1" : "_2")).Content = Convert.ToInt32(((Label)FindName(currrent_played_by == "cross" ? "_1" : "_2")).Content) + 1;
                        Button_Click_1(null, null);
                        break;
                    }
                default:
                    {
                        switch (occupied_boxes)
                        {
                            case 9:
                                {
                                    switch (notificationsenabled)
                                    {
                                        case true:
                                            {
                                                MessageBox.Show("Match is Tied!", "No Winner", MessageBoxButton.OK, MessageBoxImage.Information);
                                                break;
                                            }
                                    }
                                    _3.Content = Convert.ToInt32(_3.Content) + 1;
                                    Button_Click_1(null, null);
                                    break;
                                }
                        }
                        break;
                    }
                        
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           Box_12.Source = Box_10.Source = Box_11.Source = Box_20.Source = Box_22.Source = Box_21.Source = Box_02.Source = Box_01.Source = Box_00.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("Resources\\Images\\white.png", UriKind.Relative));
           occupied_boxes = 0;
           selectednotempty_label.Visibility = Visibility.Hidden;
           someonewon = false;
           turn_label.Content = "Turn of " + (turn = ((turn == "Player 1" || turn == "You") ? (vsai == true ? "You" : "Player 2") : (vsai == true ? "You" : "Player 1")));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TicTacToe_By_MS.Close();
        }

        private void About_Click_1(object sender, RoutedEventArgs e)
        {
            Help_expander.IsExpanded = false;
            AboutBox1 aboutbox1 = new AboutBox1();
            aboutbox1.Show();
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            vsai = vsai_checkbox.IsChecked.Value;
            vsai_changed();
            Button_Click_1(null, null);
            Game_Expander.IsExpanded = false;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Help_expander.IsExpanded = false; 
            MessageBox.Show("This is a  Simple Game  in which  Win  is achieved when\nthree consecutive blocks in a Row, Column or Diagonal\nare occupied before the opponent does the same.");
	    }

        private void Help_expander_Expanded(object sender, RoutedEventArgs e)
        {
            Game_Expander.IsExpanded = false;
        }

        private void Game_Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Help_expander.IsExpanded = false;
        }

        private void Enable_Notifications_Changed(object sender, RoutedEventArgs e)
        {
            notificationsenabled = notification_checkbox.IsChecked.Value;
            Game_Expander.IsExpanded = false;
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Game_Expander.IsExpanded = Help_expander.IsExpanded = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mssaggoo.blogspot.in");
        }
    }
}