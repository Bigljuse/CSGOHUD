using CSGOHUD.Models.Enums;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSGOHUD.Controls.Middle
{
    public partial class Player_Panel_Middle
    {
        public static readonly DependencyProperty HealthProperty =
            DependencyProperty.Register("Health", typeof(int), typeof(Player_Panel_Middle), new UIPropertyMetadata(0));
        public static readonly DependencyProperty NickNameProperty =
            DependencyProperty.Register("NickName", typeof(string), typeof(Player_Panel_Middle), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty C4Property =
            DependencyProperty.Register("C4", typeof(bool), typeof(Player_Panel_Middle), new UIPropertyMetadata(false));
        public static readonly DependencyProperty TeamColorProperty =
            DependencyProperty.Register("TeamColor", typeof(Brush), typeof(Player_Panel_Middle), new UIPropertyMetadata(Brushes.LightGray));
        public static readonly DependencyProperty ArmorBodyProperty =
            DependencyProperty.Register("ArmorBody", typeof(int), typeof(Player_Panel_Middle), new UIPropertyMetadata(0));
        public static readonly DependencyProperty ArmorHeadProperty =
            DependencyProperty.Register("ArmorHead", typeof(bool), typeof(Player_Panel_Middle), new UIPropertyMetadata(false));
        private static readonly DependencyProperty TeamProperty =
            DependencyProperty.Register("Team", typeof(PlayerTeam), typeof(Player_Panel_Middle), new UIPropertyMetadata(PlayerTeam.None));
        private static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(Player_Panel_Middle));
        private static readonly DependencyProperty ShowProperty =
            DependencyProperty.Register("Show", typeof(bool), typeof(Player_Panel_Middle), new UIPropertyMetadata(false));
        private static readonly DependencyProperty AmmoProperty =
            DependencyProperty.Register("Ammo", typeof(string), typeof(Player_Panel_Middle), new UIPropertyMetadata("0/0"));

        public int Health
        {
            get { return (int)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }
        public string NickName
        {
            get { return (string)GetValue(NickNameProperty); }
            set { SetValue(NickNameProperty, value); }
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
        public Brush TeamColor
        {
            get { return (Brush)GetValue(TeamColorProperty); }
            set { SetValue(TeamColorProperty, value); }
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
        public bool Show
        {
            get { return (bool)GetValue(ShowProperty); }
            set
            {
                if (value == true)
                    Panel_Middle.Visibility = Visibility.Visible;
                else
                    Panel_Middle.Visibility = Visibility.Collapsed;

                SetValue(ShowProperty, value);
            }
        }
        public PlayerTeam Team
        {
            get { return (PlayerTeam)GetValue(TeamProperty); }
            set
            {
                if (value == PlayerTeam.CT)
                    TeamColor = new BrushConverter().ConvertFromString("#FF437BFF") as Brush;
                else if (value == PlayerTeam.T)
                    TeamColor = new BrushConverter().ConvertFromString("#FFFB2860") as Brush;
                else
                    TeamColor = Brushes.DarkGray;

                SetValue(TeamProperty, value);
            }
        }
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public string Ammo
        {
            get { return (string)GetValue(AmmoProperty); }
            set { SetValue(AmmoProperty, value); }
        }
    }
}
