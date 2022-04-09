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
using CSGOHUD.Models.Enums;
using CSGOHUD.Models.Player;
using CSGOHUD.Models.Player.Components;

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
        }

        private void GameListener_GameStateChanged(GameStateModel gameState)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (gameState.Map != null)
                {
                    TeamStatistics_Menu.T_RoundsWon = gameState.Map.Team_T.Score;
                    TeamStatistics_Menu.CT_RoundsWon = gameState.Map.Team_CT.Score;
                }

                if (gameState.Player != null)
                    SetPlayerViewer(gameState.Player);
            }));
        }

        private void SetPlayerViewer(PlayerModel spectatedPlayer)
        {

            PlayerViewer.NickName = spectatedPlayer.Name;
            PlayerViewer.Health = spectatedPlayer.State.Health.ToString();
            PlayerViewer.Armor = spectatedPlayer.State.Armor.ToString();
            PlayerViewer.Kills = spectatedPlayer.Match_Stats.Kills.ToString();
            PlayerViewer.Deaths = spectatedPlayer.Match_Stats.Deaths.ToString();
            PlayerViewer.Team = spectatedPlayer.Team.ToString() == "T" ? TeamEnum.T : TeamEnum.CT;

            WeaponModel? activeWeapon = spectatedPlayer.Weapons.Find(weapon => weapon.State == WeaponState.active.ToString());
            if (activeWeapon != null)
            {
                PlayerViewer.AmmoClip = activeWeapon.Ammo_Clip.ToString();
                PlayerViewer.AmmoClipMax = activeWeapon.Ammo_Clip_max.ToString();
            }
        }
    }
}
