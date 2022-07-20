using CSGO;
using CSGO.Models;
using CSGO.Models.Enums;
using CSGO.Models.Player;
using CSGO.Models.Player.Components;
using CSGOHUD.Controls.LeftSided;
using CSGOHUD.Controls.RightSided;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Settings = CSGOHUD.Properties.Settings;

namespace CSGOHUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerModel? _selectedPlayer = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listener gameListener = new Listener("127.0.0.1", 3000);

            gameListener.MessageRecieved += MessageRecieved;
            gameListener.Start();

            StartOvershowing(1000);
        }

        private void MessageRecieved(string jsonMessage)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                //texts.Text = jsonMessage;
                UpdateUI(GameProcessor.ProcessGameState(jsonMessage));
            }));
        }

        private void UpdateMiddlePanel(PlayerModel? player)
        {
            if (player == null ||
                player.State.Health <= 0)
            {
                Panel_Middle.Show = false;
                return;
            }

            _selectedPlayer = player;

            Panel_Middle.NickName = player.Name;
            Panel_Middle.Health = player.State.Health;
            Panel_Middle.ArmorBody = player.State.Armor;
            Panel_Middle.ArmorHead = player.State.Helmet;
            Panel_Middle.Team = player.GetTeam();
            Panel_Middle.Show = true;

            WeaponModel? selected_weapon = player.Weapons.Values.Where(x => x.State.Contains(WeaponState.active.ToString(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (selected_weapon != null)
                Panel_Middle.Ammo = $"{selected_weapon.Ammo_Clip}/{selected_weapon.Ammo_Clip_max}";
            else
                Panel_Middle.Ammo = $"0/0";

            Panel_Middle.Grenades_Check(player.GetGrenades());
        }

        private void HideSidePanels()
        {
            for (int playerId = 0; playerId < 10; playerId++)
                UpdateSidePanel(new PlayerModel() { Observer_slot = playerId });
        }

        private void UpdateTopPanel(GameStateModel gameState)
        {
         //  if (gameState.Bomb.StateChanged == true)
         //  {
         //      if (gameState.Bomb.State == "planted")
         //      {
         //          Settings.Default.BombTimerStart = Settings.Default.BombTimerMax - Convert.ToDouble(gameState.Bomb.countdown.Replace('.',','));
         //          TopPanel.Bomb = Controls.TopMenu.Enums.BombState.planted;
         //      }
         //      if (gameState.Bomb.State == "defused")
         //          TopPanel.Bomb = Controls.TopMenu.Enums.BombState.defused;
         //
         //      if (gameState.Round.Bomb == "exploded")
         //          TopPanel.Bomb = Controls.TopMenu.Enums.BombState.exploded;
         //  }
         //  else if (gameState.Map.RoundChanged == true || gameState.Round.PhaseChanged == true)
         //  {
         //      TopPanel.LeftScore = gameState.Map.Team_CT.Score;
         //      TopPanel.RightScore = gameState.Map.Team_T.Score;
         //
         //      if (gameState.Bomb.State == "planted")
         //          TopPanel.Bomb = Controls.TopMenu.Enums.BombState.planted;
         //      else if (gameState.Bomb.State == "defused")
         //          TopPanel.Bomb = Controls.TopMenu.Enums.BombState.defused;
         //      else
         //      {
         //          TopPanel.Start_Timer(Convert.ToDouble(gameState.Phase_Countdowns.Phase_Ends_In.Replace('.', ',')));
         //      }
         //  }
        }

        private void UpdateUI(GameStateModel gameState)
        {
            //texts.Text = gameState.message;
            //var mapPath = MapOverviewer.GetMap(gameState.Map.Name);

            UpdateTopPanel(gameState);

            if (gameState.Player.NameChanged == true)
                UpdateMiddlePanel(gameState.Player);

            if (gameState.Player?.Activity == "playing")
            {
                UpdatePlayers(gameState.Players);
                UpdateMiddlePanel(gameState.Player);
            }

            if (gameState.Player?.ActivityChanged == false)
                return;

            switch (gameState.Player?.Activity)
            {
                case "menu": UpdateMiddlePanel(null); HideSidePanels(); break;
                case "playing": UpdateMiddlePanel(gameState.Player); break;
            }
        }

        private void UpdatePlayers(Dictionary<string, PlayerModel> players)
        {
            players.Values.ToList().ForEach(UpdateSidePanel);
        }

        private void UpdateSidePanel(PlayerModel player)
        {
            if (player == null || player.Observer_slot == -1)
                return;

            if (player.Observer_slot == 1)
                UpdateLeftPanel(Panel_Left_1, player);
            if (player.Observer_slot == 2)
                UpdateLeftPanel(Panel_Left_2, player);
            if (player.Observer_slot == 3)
                UpdateLeftPanel(Panel_Left_3, player);
            if (player.Observer_slot == 4)
                UpdateLeftPanel(Panel_Left_4, player);
            if (player.Observer_slot == 5)
                UpdateLeftPanel(Panel_Left_5, player);
            if (player.Observer_slot == 6)
                UpdateRightPanel(Panel_Right_6, player);
            if (player.Observer_slot == 7)
                UpdateRightPanel(Panel_Right_7, player);
            if (player.Observer_slot == 8)
                UpdateRightPanel(Panel_Right_8, player);
            if (player.Observer_slot == 9)
                UpdateRightPanel(Panel_Right_9, player);
            if (player.Observer_slot == 0)
                UpdateRightPanel(Panel_Right_0, player);
        }

        private void UpdateLeftPanel(Player_Panel_Left panel, PlayerModel player)
        {
            if (panel.Team != player.GetTeam())
                panel.Team = player.GetTeam();

            if (panel.NickName != player.Name)
                panel.NickName = player.Name;

            if (panel.Health != player.State.Health)
                panel.Health = player.State.Health;

            if (panel.ArmorBody != player.State.Armor)
                panel.ArmorBody = player.State.Armor;

            if (panel.ArmorHead != player.State.Helmet)
                panel.ArmorHead = player.State.Helmet;

            Weapon topWeapon = player.GetTopWeapon();

            if (panel.Weapon != topWeapon)
                panel.Weapon = topWeapon;

            if (panel.Flashed != player.State.Flashed)
                panel.Flashed = player.State.Flashed;

            if (panel.Smoked != player.State.Smoked)
                panel.Smoked = player.State.Smoked;

            //if (panel.Burning != player.State.Burning)
            //    panel.Burning = player.State.Burning;

            if (panel.NickName == _selectedPlayer?.Name)
                panel.Selected = true;
            else
                panel.Selected = false;

            if (panel.Defuzer != player.State.defusekit)
                panel.Defuzer = player.State.defusekit;

            if (panel.C4 != (player.Weapons.Values.Where(x => x.Type == "C4") != null))
                panel.C4 = player.Weapons.Values.Where(x => x.Type == "C4") != null;

            if (panel.Money != player.State.Money)
                panel.Money = player.State.Money;

            if (panel.Kills != player.Match_Stats.Kills.ToString())
                panel.Kills = player.Match_Stats.Kills.ToString();

            if (panel.KillsStreak != player.State.Round_kills)
                panel.KillsStreak = player.State.Round_kills;

            if (panel.Deaths != player.Match_Stats.Deaths.ToString())
                panel.Deaths = player.Match_Stats.Deaths.ToString();

            panel.Grenades_Check(player.GetGrenades());
        }

        private void UpdateRightPanel(Player_Panel_Right panel, PlayerModel player)
        {
            if (panel.Team != player.GetTeam())
                panel.Team = player.GetTeam();

            if (panel.NickName != player.Name)
                panel.NickName = player.Name;

            if (panel.Health != player.State.Health)
                panel.Health = player.State.Health;

            if (panel.ArmorBody != player.State.Armor)
                panel.ArmorBody = player.State.Armor;

            if (panel.ArmorHead != player.State.Helmet)
                panel.ArmorHead = player.State.Helmet;

            if (panel.Weapon != player.GetTopWeapon())
                panel.Weapon = player.GetTopWeapon();

            if (panel.Flashed != player.State.Flashed)
                panel.Flashed = player.State.Flashed;

            if (panel.Smoked != player.State.Smoked)
                panel.Smoked = player.State.Smoked;

            //if (panel.Burning != player.State.Burning)
            //    panel.Burning = player.State.Burning;

            if (panel.NickName == _selectedPlayer?.Name)
                panel.Selected = true;
            else
                panel.Selected = false;

            if (panel.Defuzer != player.State.defusekit)
                panel.Defuzer = player.State.defusekit;

            if (panel.C4 != (player.Weapons.Values.Where(x => x.Type == "C4") != null))
                panel.C4 = player.Weapons.Values.Where(x => x.Type == "C4") != null;

            if (panel.Money != player.State.Money)
                panel.Money = player.State.Money;

            if (panel.Kills != player.Match_Stats.Kills.ToString())
                panel.Kills = player.Match_Stats.Kills.ToString();

            if (panel.KillsStreak != player.State.Round_kills)
                panel.KillsStreak = player.State.Round_kills;

            if (panel.Deaths != player.Match_Stats.Deaths.ToString())
                panel.Deaths = player.Match_Stats.Deaths.ToString();

            panel.Grenades_Check(player.GetGrenades());
        }
    }
}
