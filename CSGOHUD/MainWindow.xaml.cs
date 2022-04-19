using CSGOHUD.Controls.LeftSided;
using CSGOHUD.Controls.RightSided;
using CSGOHUD.Dictionaries;
using CSGOHUD.Models;
using CSGOHUD.Models.Enums;
using CSGOHUD.Models.Extensions;
using CSGOHUD.Models.Player;
using CSGOHUD.Models.Player.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace CSGOHUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);

        private PlayerModel? _selected_Player = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task BringToFront()
        {
            while (true)
            {
                await Task.Run(() => Task.Delay(5));
                SetWindowPos(Process.GetCurrentProcess().MainWindowHandle, IntPtr.Parse("-1"), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0200);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameListener gameListener = new GameListener();
            gameListener.GameStateChanged += GameListener_GameStateChanged;

            await BringToFront();
        }

        private void GameListener_GameStateChanged(GameStateModel gameState)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                _selected_Player = gameState.Player;
                Show_Slected_Player(_selected_Player);

                if (gameState.Player != null)
                    SetPlayerViewer(gameState.Player);

                PlayerModel? player = new PlayerModel();

                for (int playerId = 1; playerId < 11; playerId++)
                {
                    if (gameState.AllPlayers.Players.Count() >= playerId)
                        player = gameState.AllPlayers.Players.ToList()[playerId - 1];
                    else
                        player = new PlayerModel();

                    player.Observer_slot = playerId == 11 ? 0 : player.Observer_slot;

                    Update_Panel(player);
                }
            }));
        }

        private void SetPlayerViewer(PlayerModel spectatedPlayer)
        {
            //PlayerViewer.NickName = spectatedPlayer.Name;
            //PlayerViewer.Health = spectatedPlayer.State.Health.ToString();
            //PlayerViewer.Armor = spectatedPlayer.State.Armor.ToString();
            //PlayerViewer.Kills = spectatedPlayer.Match_Stats.Kills.ToString();
            //PlayerViewer.Deaths = spectatedPlayer.Match_Stats.Deaths.ToString();
            //PlayerViewer.Team = spectatedPlayer.Team.ToString() == "T" ? PlayerTeam.T : PlayerTeam.CT;

            //WeaponModel? activeWeapon = spectatedPlayer.Weapons.Find(weapon => weapon.State == WeaponState.active.ToString());
            //if (activeWeapon != null)
            //{
            //    PlayerViewer.AmmoClip = activeWeapon.Ammo_Clip.ToString();
            //    PlayerViewer.AmmoClipMax = activeWeapon.Ammo_Clip_max.ToString();
            //}
        }

        private List<Grenade> GetGrenades(List<WeaponModel> weapons)
        {
            List<Grenade> grenades = new List<Grenade>();
            List<WeaponModel> player_grenades = weapons.Where(x => x.Type.Contains("Grenade", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (WeaponModel grenade in player_grenades)
                grenades.Add(WeaponsDictionary.Grenades[grenade.Name]);

            return grenades;
        }

        private Weapon GetTopWeapon(List<WeaponModel> weapons)
        {
            if (weapons.Count == 0)
                return Weapon.None;

            WeaponModel knife = weapons.Find(x => x.Type.Contains("Knife", StringComparison.OrdinalIgnoreCase));
            WeaponModel Pistol = weapons.Find(x => x.Type.Contains("Pistol", StringComparison.OrdinalIgnoreCase));
            WeaponModel MainGun = weapons.Find(x =>
                x.Type.Contains("Rifle", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Submachine", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Shotgun", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Machine", StringComparison.OrdinalIgnoreCase));

            if (MainGun != null)
                return WeaponsDictionary.Weapons[MainGun.Name];

            if (Pistol != null)
                return WeaponsDictionary.Weapons[Pistol.Name];

            return WeaponsDictionary.Weapons[knife.Name];
        }

        private void Show_Slected_Player(PlayerModel player)
        {
            if (player == null ||
                player.State.Health <= 0)
            {
                Panel_Middle.Show = false;
                Panel_Middle.NickName = String.Empty;
                Panel_Middle.Health = 0;
                Panel_Middle.ArmorBody = 0;
                Panel_Middle.ArmorHead = false;
                Panel_Middle.Team = PlayerTeam.None;
                Panel_Middle.Grenades_Check(new List<Grenade>());
                return;
            }

            Panel_Middle.Show = true;
            Panel_Middle.NickName = player.Name;
            Panel_Middle.Health = player.State.Health;
            Panel_Middle.ArmorBody = player.State.Armor;
            Panel_Middle.ArmorHead = player.State.Helmet;
            Panel_Middle.Team = player.GetTeam();

            WeaponModel selected_weapon = player.Weapons.Find(x => x.State.Contains(WeaponState.active.ToString(), StringComparison.CurrentCultureIgnoreCase));

            if (selected_weapon != null)
                Panel_Middle.Ammo = $"{selected_weapon.Ammo_Clip}/{selected_weapon.Ammo_Clip_max}";
            else
                Panel_Middle.Ammo = $"0/0";

            Panel_Middle.Grenades_Check(GetGrenades(player.Weapons));
        }

        private void Update_Panel(PlayerModel player)
        {
            if (player.Observer_slot == -1)
                return;

            if (player.Observer_slot == 1)
                Update_Left_Panel(Panel_Left_1, player);
            if (player.Observer_slot == 2)
                Update_Left_Panel(Panel_Left_2, player);
            if (player.Observer_slot == 3)
                Update_Left_Panel(Panel_Left_3, player);
            if (player.Observer_slot == 4)
                Update_Left_Panel(Panel_Left_4, player);
            if (player.Observer_slot == 5)
                Update_Left_Panel(Panel_Left_5, player);
            if (player.Observer_slot == 6)
                Update_Right_Panel(Panel_Right_6, player);
            if (player.Observer_slot == 7)
                Update_Right_Panel(Panel_Right_7, player);
            if (player.Observer_slot == 8)
                Update_Right_Panel(Panel_Right_8, player);
            if (player.Observer_slot == 9)
                Update_Right_Panel(Panel_Right_9, player);
            if (player.Observer_slot == 0)
                Update_Right_Panel(Panel_Right_0, player);
        }

        private void Update_Left_Panel(Player_Panel_Left panel, PlayerModel player)
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

            if (panel.Weapon != GetTopWeapon(player.Weapons))
                panel.Weapon = GetTopWeapon(player.Weapons);

            if (panel.Flashed != player.State.Flashed)
                panel.Flashed = player.State.Flashed;

            if (panel.Smoked != player.State.Smoked)
                panel.Smoked = player.State.Smoked;

            //if (panel.Burning != player.State.Burning)
            //    panel.Burning = player.State.Burning;

            if (panel.NickName != _selected_Player.Name)
                panel.Selected = false;
            else
                panel.Selected = true;

            if (panel.Defuzer != player.State.defusekit)
                panel.Defuzer = player.State.defusekit;

            if (panel.C4 != (player.Weapons.Find(x => x.Type == "C4") != null))
                panel.C4 = player.Weapons.Find(x => x.Type == "C4") != null;

            if (panel.Money != player.State.Money)
                panel.Money = player.State.Money;

            if (panel.Kills != player.Match_Stats.Kills.ToString())
                panel.Kills = player.Match_Stats.Kills.ToString();

            if (panel.KillsStreak != player.State.Round_kills)
                panel.KillsStreak = player.State.Round_kills;

            if (panel.Deaths != player.Match_Stats.Deaths.ToString())
                panel.Deaths = player.Match_Stats.Deaths.ToString();

            panel.Grenades_Check(GetGrenades(player.Weapons));
        }

        private void Update_Right_Panel(Player_Panel_Right panel, PlayerModel player)
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

            if (panel.Weapon != GetTopWeapon(player.Weapons))
                panel.Weapon = GetTopWeapon(player.Weapons);

            if (panel.Flashed != player.State.Flashed)
                panel.Flashed = player.State.Flashed;

            if (panel.Smoked != player.State.Smoked)
                panel.Smoked = player.State.Smoked;

            //if (panel.Burning != player.State.Burning)
            //    panel.Burning = player.State.Burning;

            if (panel.NickName != _selected_Player.Name)
                panel.Selected = false;
            else
                panel.Selected = true;

            if (panel.Defuzer != player.State.defusekit)
                panel.Defuzer = player.State.defusekit;

            if (panel.C4 != (player.Weapons.Find(x => x.Type == "C4") != null))
                panel.C4 = player.Weapons.Find(x => x.Type == "C4") != null;

            if (panel.Money != player.State.Money)
                panel.Money = player.State.Money;

            if (panel.Kills != player.Match_Stats.Kills.ToString())
                panel.Kills = player.Match_Stats.Kills.ToString();

            if (panel.KillsStreak != player.State.Round_kills)
                panel.KillsStreak = player.State.Round_kills;

            if (panel.Deaths != player.Match_Stats.Deaths.ToString())
                panel.Deaths = player.Match_Stats.Deaths.ToString();

            panel.Grenades_Check(GetGrenades(player.Weapons));
        }
    }
}
