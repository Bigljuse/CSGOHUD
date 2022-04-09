using CSGOHUD.Models.Enums;
using System;
using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls
{
    public partial class PlayerViewer
    {
        public static readonly DependencyProperty PlayerImageSourceProperty = DependencyProperty.Register("PlayerImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("../Images/T-CT.jpg"));
        public static readonly DependencyProperty FlagImageProperty = DependencyProperty.Register("FlagImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty HealthImageProperty = DependencyProperty.Register("HealthImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty ArmorImageProperty = DependencyProperty.Register("ArmorImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty AmmoImageProperty = DependencyProperty.Register("AmmoImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty MolotovImageProperty = DependencyProperty.Register("MolotovImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty ImpactImageProperty = DependencyProperty.Register("ImpactImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty SmokeImageProperty = DependencyProperty.Register("SmokeImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty FlashImageProperty = DependencyProperty.Register("FlashImageSource", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty NickNameProperty = DependencyProperty.Register("NickName", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty ADRProperty = DependencyProperty.Register("ADR", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty KillsProperty = DependencyProperty.Register("Kills", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty AssistsProperty = DependencyProperty.Register("Assists", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty DeathsProperty = DependencyProperty.Register("Deaths", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty HealthProperty = DependencyProperty.Register("Health", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty ArmorProperty = DependencyProperty.Register("Armor", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty AmmoClipProperty = DependencyProperty.Register("AmmoClip", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty AmmoClipMaxProperty = DependencyProperty.Register("AmmoClipMax", typeof(string), typeof(PlayerViewer), new UIPropertyMetadata("0"));
        public static readonly DependencyProperty TeamProperty = DependencyProperty.Register("Team", typeof(TeamEnum), typeof(PlayerViewer), new UIPropertyMetadata(TeamEnum.CT));
        public static readonly DependencyProperty TeamColorProperty = DependencyProperty.Register("TeamColor", typeof(Brush), typeof(PlayerViewer), new UIPropertyMetadata(Brushes.DarkGray));

        public string PlayerImageSource
        {
            get { return (string)GetValue(PlayerImageSourceProperty); }
            set { SetValue(PlayerImageSourceProperty, value); }
        }

        public Brush TeamColor
        {
            get { return (Brush)GetValue(TeamColorProperty); }
            set { SetValue(TeamColorProperty, value); }
        }

        public TeamEnum Team
        {
            get { return (TeamEnum)GetValue(TeamProperty); }
            set
            {
                SetValue(TeamProperty, value);

                if ((TeamEnum)GetValue(TeamProperty) == TeamEnum.T)
                    SetValue(TeamColorProperty, new BrushConverter().ConvertFromString("#FFE7B234"));
                if ((TeamEnum)GetValue(TeamProperty) == TeamEnum.CT)
                    TeamColor = new BrushConverter().ConvertFromString("#FF60ABC9") as Brush;
            }
        }

        public string FlagImageSource
        {
            get { return (string)GetValue(FlagImageProperty); }
            set { SetValue(FlagImageProperty, value); }
        }

        public string HealthImageSource
        {
            get { return (string)GetValue(HealthImageProperty); }
            set { SetValue(HealthImageProperty, value); }
        }

        public string ArmorImageSource
        {
            get { return (string)GetValue(ArmorImageProperty); }
            set { SetValue(ArmorImageProperty, value); }
        }

        public string AmmoImageSource
        {
            get { return (string)GetValue(AmmoImageProperty); }
            set { SetValue(AmmoImageProperty, value); }
        }

        public string SmokeImageSource
        {
            get { return (string)GetValue(SmokeImageProperty); }
            set { SetValue(SmokeImageProperty, value); }
        }

        public string ImpactImageSource
        {
            get { return (string)GetValue(ImpactImageProperty); }
            set { SetValue(ImpactImageProperty, value); }
        }

        public string MolotovImageSource
        {
            get { return (string)GetValue(MolotovImageProperty); }
            set { SetValue(MolotovImageProperty, value); }
        }

        public string FlashImageSource
        {
            get { return (string)GetValue(FlashImageProperty); }
            set { SetValue(FlashImageProperty, value); }
        }

        public string NickName
        {
            get { return (string)GetValue(NickNameProperty); }
            set { SetValue(NickNameProperty, value); }
        }

        public string ADR
        {
            get { return (string)GetValue(ADRProperty); }
            set { SetValue(ADRProperty, value); }
        }

        public string Kills
        {
            get { return (string)GetValue(KillsProperty); }
            set { SetValue(KillsProperty, value); }
        }

        public string Assists
        {
            get { return (string)GetValue(AssistsProperty); }
            set { SetValue(AssistsProperty, value); }
        }

        public string Deaths
        {
            get { return (string)GetValue(DeathsProperty); }
            set { SetValue(DeathsProperty, value); }
        }

        public string Health
        {
            get { return (string)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }

        public string Armor
        {
            get { return (string)GetValue(ArmorProperty); }
            set { SetValue(ArmorProperty, value); }
        }

        public string AmmoClip
        {
            get { return (string)GetValue(AmmoClipProperty); }
            set { SetValue(AmmoClipProperty, value); }
        }

        public string AmmoClipMax
        {
            get { return (string)GetValue(AmmoClipMaxProperty); }
            set { SetValue(AmmoClipMaxProperty, value); }
        }
    }
}
