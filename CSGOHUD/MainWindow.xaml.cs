using System;
using System.Collections.Generic;
using System.IO;
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

using CSGOHUD.Controls;
using CSGOHUD.Models;

namespace CSGOHUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameListener gameListener = new GameListener();
            gameListener.GameStateChanged += GameListener_GameStateChanged;
            gameListener.TextChanged += ChangedText;
        }

        private void GameListener_GameStateChanged(GameStateModel gameState)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                TextBlock_Timer.Text = gameState.Phase_Countdowns.Phase_Ends_In;
                TextBlock_CT_TeamName.Text = gameState.Player.Name;
            }));
        }

        private void ChangedText(string text)
        {
           // Application.Current.Dispatcher.Invoke(new Action(() => { TextBlock_Text.Text = text; }));
        }
    }
}
