using CSGO.Models.Enums;
using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls.RightSided
{
    public partial class Player_Panel_Right
    {
        public static readonly DependencyProperty DeadProperty =
            DependencyProperty.Register("Dead", typeof(bool), typeof(Player_Panel_Right), new UIPropertyMetadata(true));
        public static readonly DependencyProperty HealthProperty =
            DependencyProperty.Register("Health", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty NickNameProperty =
            DependencyProperty.Register("NickName", typeof(string), typeof(Player_Panel_Right), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty KillsProperty =
            DependencyProperty.Register("Kills", typeof(string), typeof(Player_Panel_Right), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty KillsStreakProperty =
            DependencyProperty.Register("KillsStreak", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty DeathsProperty =
            DependencyProperty.Register("Deaths", typeof(string), typeof(Player_Panel_Right), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty MoneyProperty =
            DependencyProperty.Register("Money", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty DefuzerProperty =
            DependencyProperty.Register("Defuzer", typeof(bool), typeof(Player_Panel_Right), new UIPropertyMetadata(false));
        public static readonly DependencyProperty C4Property =
            DependencyProperty.Register("C4", typeof(bool), typeof(Player_Panel_Right), new UIPropertyMetadata(false));
        public static readonly DependencyProperty TeamBrushProperty =
            DependencyProperty.Register("TeamBrush", typeof(Brush), typeof(Player_Panel_Right), new UIPropertyMetadata(Brushes.LightGray));
        public static readonly DependencyProperty TeamColorProperty =
            DependencyProperty.Register("TeamColor", typeof(Color), typeof(Player_Panel_Right), new UIPropertyMetadata(Colors.LightGray));
        public static readonly DependencyProperty ArmorBodyProperty =
            DependencyProperty.Register("ArmorBody", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty FlashedProperty =
            DependencyProperty.Register("Flashed", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty SmokedProperty =
            DependencyProperty.Register("Smoked", typeof(int), typeof(Player_Panel_Right), new UIPropertyMetadata(0));
        public static readonly DependencyProperty ArmorHeadProperty =
            DependencyProperty.Register("ArmorHead", typeof(bool), typeof(Player_Panel_Right), new UIPropertyMetadata(false));
        public static readonly DependencyProperty WeaponProperty =
            DependencyProperty.Register("Weapon", typeof(Weapon), typeof(Player_Panel_Right), new UIPropertyMetadata(Weapon.None));
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(Player_Panel_Right));
        private static readonly DependencyProperty TeamProperty =
            DependencyProperty.Register("Team", typeof(PlayerTeam), typeof(Player_Panel_Right), new UIPropertyMetadata(PlayerTeam.None));
        private static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(Player_Panel_Right), new UIPropertyMetadata(false));

        public delegate void PlayerDiedDelegate();
        public event PlayerDiedDelegate PlayerDied = new PlayerDiedDelegate(() => { });

        public delegate void PlayerSpawnedDelegate();
        public event PlayerSpawnedDelegate PlayerSpawned = new PlayerSpawnedDelegate(() => { });

        public bool Dead
        {
            get { return (bool)GetValue(DeadProperty); }
            set
            {
                if (Dead == true && value == false)
                    PlayerSpawned.Invoke();

                if (Dead == false && value == true)
                    PlayerDied.Invoke();

                SetValue(DeadProperty, value);
            }
        }
        public int Health
        {
            get { return (int)GetValue(HealthProperty); }
            set
            {
                if (value > 0)
                    Dead = false;
                else if (value == 0)
                    Dead = true;

                Play_NumberHit(Health, value);
                Play_HoverDamage();
                SetValue(HealthProperty, value);
                Play_Hit();
            }
        }
        public string NickName
        {
            get { return (string)GetValue(NickNameProperty); }
            set { SetValue(NickNameProperty, value); }
        }
        public string Kills
        {
            get { return (string)GetValue(KillsProperty); }
            set { SetValue(KillsProperty, value); }
        }
        public int KillsStreak
        {
            get { return (int)GetValue(KillsStreakProperty); }
            set
            {
                if (value == 0)
                    Grid_KillsStreak.Visibility = Visibility.Collapsed;
                else if (Grid_KillsStreak.Visibility == Visibility.Collapsed)
                    Grid_KillsStreak.Visibility = Visibility.Visible;

                SetValue(KillsStreakProperty, value);
            }
        }
        public string Deaths
        {
            get { return (string)GetValue(DeathsProperty); }
            set { SetValue(DeathsProperty, value); }
        }
        public int Money
        {
            get { return (int)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }
        public bool Defuzer
        {
            get { return (bool)GetValue(DefuzerProperty); }
            set
            {
                if (value == true)
                    Viewbox_Defuzer.Visibility = Visibility.Visible;
                else
                    Viewbox_Defuzer.Visibility = Visibility.Collapsed;

                SetValue(DefuzerProperty, value);
            }
        }
        public bool C4
        {
            get { return (bool)GetValue(C4Property); }
            set
            {
                if (value == true)
                    Viewbox_C4.Visibility = Visibility.Visible;
                else
                    Viewbox_C4.Visibility = Visibility.Collapsed;

                SetValue(C4Property, value);
            }
        }
        public Brush TeamBrush
        {
            get { return (Brush)GetValue(TeamBrushProperty); }
            private set
            {
                SetValue(TeamBrushProperty, value);
                TeamColor = (Color)ColorConverter.ConvertFromString(TeamBrush.ToString());
            }
        }
        public Color TeamColor
        {
            get { return (Color)GetValue(TeamColorProperty); }
            private set { SetValue(TeamColorProperty, value); }
        }
        public int ArmorBody
        {
            get { return (int)GetValue(ArmorBodyProperty); }
            set
            {
                if (value > 0)
                    Viewbox_ArmorBody.Visibility = Visibility.Visible;
                else
                    Viewbox_ArmorBody.Visibility = Visibility.Collapsed;

                SetValue(ArmorBodyProperty, value);
            }
        }
        public int Smoked
        {
            get { return (int)GetValue(SmokedProperty); }
            set
            {
                if (value > 0)
                    Image_Smoked.Opacity = (double)value / 255;
                else
                    Image_Smoked.Opacity = 0;

                SetValue(SmokedProperty, value);
            }
        }
        public int Flashed
        {
            get { return (int)GetValue(FlashedProperty); }
            set
            {
                if (value > 0)
                    Image_Flashed.Opacity = (double)value / 255;
                else
                    Image_Flashed.Opacity = 0;

                SetValue(FlashedProperty, value);
            }
        }
        public bool ArmorHead
        {
            get { return (bool)GetValue(ArmorHeadProperty); }
            set
            {
                if (value == true)
                    Viewbox_ArmorHead.Visibility = Visibility.Visible;
                else
                    Viewbox_ArmorHead.Visibility = Visibility.Collapsed;

                SetValue(ArmorHeadProperty, value);
            }
        }
        public Weapon Weapon
        {
            get { return (Weapon)GetValue(WeaponProperty); }
            set
            {
                if (value == Weapon.None)
                {
                    Path_Weapon.Data = null;
                    return;
                }

                Path_Weapon.Data = Application.Current.Resources[value.ToString()] as Geometry;

                if (Path_Weapon.Data == null)
                    return;

                SetValue(WeaponProperty, value);
            }
        }
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set
            {
                if (value == true)
                {
                    Rectangle_Selected.Visibility = Visibility.Visible;
                    Image_HoverSelection.Visibility = Visibility.Visible;
                }
                else
                {
                    Rectangle_Selected.Visibility = Visibility.Collapsed;
                    Image_HoverSelection.Visibility = Visibility.Collapsed;
                }

                SetValue(SelectedProperty, value);
            }
        }
        public PlayerTeam Team
        {
            get { return (PlayerTeam)GetValue(TeamProperty); }
            set
            {
                if (value == PlayerTeam.CT)
                {
                    Panel_Right.Visibility = Visibility.Visible;
                    TeamBrush = new BrushConverter().ConvertFromString("#FF437BFF") as Brush;
                }
                else if (value == PlayerTeam.T)
                {
                    Panel_Right.Visibility = Visibility.Visible;
                    TeamBrush = new BrushConverter().ConvertFromString("#FFFB2860") as Brush;
                }
                else
                {
                    Panel_Right.Visibility = Visibility.Collapsed;
                    TeamBrush = Brushes.DarkGray;
                }

                SetValue(TeamProperty, value);
            }
        }
    }
}
