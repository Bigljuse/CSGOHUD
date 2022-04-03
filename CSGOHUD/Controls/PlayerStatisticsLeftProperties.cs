using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls
{
    public partial class PlayerStatisticsLeft
    {
        public static readonly DependencyProperty PlayerAliveProperty = DependencyProperty.Register("IsPlayerAlive", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty PlayerImageSourceProperty = DependencyProperty.Register("PlayerImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty MainGunProperty = DependencyProperty.Register("MainGunImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty DefuzesImageSourceProperty = DependencyProperty.Register("DefuzesImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty PistolImageSourceProperty = DependencyProperty.Register("PistolImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(10));
        public static readonly DependencyProperty PlayerNumberProperty = DependencyProperty.Register("PlayerNumber", typeof(int), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(1));
        public static readonly DependencyProperty HealthProperty = DependencyProperty.Register("Health", typeof(int), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(0));
        public static readonly DependencyProperty NickNameProperty = DependencyProperty.Register("NickName", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty KillsProperty = DependencyProperty.Register("Kills", typeof(int), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(0));
        public static readonly DependencyProperty MoneyProperty = DependencyProperty.Register("Money", typeof(int), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(0));
        public static readonly DependencyProperty HasMainGunProperty = DependencyProperty.Register("HasMainGun", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasPistolProperty = DependencyProperty.Register("HasPistol", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasMolotovProperty = DependencyProperty.Register("HasMolotov", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasFlashProperty = DependencyProperty.Register("HasFlash", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasHelmetProperty = DependencyProperty.Register("HasHelmet", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasDefusesProperty = DependencyProperty.Register("HasDefuses", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HasSmokeProperty = DependencyProperty.Register("HasSmoke", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));
        public static readonly DependencyProperty HelmetImageSourceProperty = DependencyProperty.Register("HelmetImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty FlashImageSourceProperty = DependencyProperty.Register("FlashImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty SmokeImageSourceProperty = DependencyProperty.Register("SmokeImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty ImpactImageSourceProperty = DependencyProperty.Register("ImpactImageSource", typeof(string), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(string.Empty));

        public bool IsPlayerAlive
        {
            get { return (bool)GetValue(PlayerAliveProperty); }
            set { SetValue(PlayerAliveProperty, value); }
        }
        public string PlayerImageSource
        {
            get { return (string)GetValue(PlayerImageSourceProperty); }
            set { SetValue(PlayerImageSourceProperty, value); }
        }
        public string MainGunImageSource
        {
            get { return (string)GetValue(MainGunProperty); }
            set { SetValue(MainGunProperty, value); }
        }
        public string DefuzesImageSource
        {
            get { return (string)GetValue(DefuzesImageSourceProperty); }
            set { SetValue(DefuzesImageSourceProperty, value); }
        }
        public string PistolImageSource
        {
            get { return (string)GetValue(PistolImageSourceProperty); }
            set { SetValue(PistolImageSourceProperty, value); }
        }
        public string ImpactImageSource
        {
            get { return (string)GetValue(ImpactImageSourceProperty); }
            set { SetValue(ImpactImageSourceProperty, value); }
        }
        public string SmokeImageSource
        {
            get { return (string)GetValue(SmokeImageSourceProperty); }
            set { SetValue(SmokeImageSourceProperty, value); }
        }
        public string FlashImageSource
        {
            get { return (string)GetValue(FlashImageSourceProperty); }
            set { SetValue(FlashImageSourceProperty, value); }
        }
        public string HelmetImageSource
        {
            get { return (string)GetValue(HelmetImageSourceProperty); }
            set { SetValue(HelmetImageSourceProperty, value); }
        }
        public bool HasSmoke
        {
            get { return (bool)GetValue(HasSmokeProperty); }
            set { SetValue(HasSmokeProperty, value); }
        }
        public bool HasDefuses
        {
            get { return (bool)GetValue(HasDefusesProperty); }
            set
            {
                SetValue(HasDefusesProperty, value);
                if (value == true)
                {
                    Image_Defuzes.Visibility = Visibility.Visible;
                    return;
                }
                Image_Defuzes.Visibility = Visibility.Hidden;
            }
        }
        public bool HasHelmet
        {
            get { return (bool)GetValue(HasHelmetProperty); }
            set
            {
                SetValue(HasHelmetProperty, value);
                if (value == true)
                {
                    Image_Helmet.Visibility = Visibility.Visible;
                    return;
                }
                Image_Helmet.Visibility = Visibility.Hidden;
            }
        }
        public bool HasFlash
        {
            get { return (bool)GetValue(HasFlashProperty); }
            set { SetValue(HasFlashProperty, value); }
        }
        public bool HasMolotov
        {
            get { return (bool)GetValue(HasMolotovProperty); }
            set { SetValue(HasMolotovProperty, value); }
        }
        public bool HasPistol
        {
            get { return (bool)GetValue(HasPistolProperty); }
            set { SetValue(HasPistolProperty, value); }
        }
        public bool HasMainGun
        {
            get { return (bool)GetValue(HasMainGunProperty); }
            set { SetValue(HasMainGunProperty, value); }
        }
        public int Money
        {
            get { return (int)GetValue(MoneyProperty); }
            set
            {
                SetValue(MoneyProperty, value);
                if (value >= 1000)
                {
                    TextBlock_Money.Foreground = new SolidColorBrush(Colors.LightGray);
                    return;
                }
                TextBlock_Money.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }
        public int Kills
        {
            get { return (int)GetValue(KillsProperty); }
            set { SetValue(KillsProperty, value); }
        }
        public string NickName
        {
            get { return (string)GetValue(NickNameProperty); }
            set { SetValue(NickNameProperty, value); }
        }
        public int Health
        {
            get { return (int)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }
        public int PlayerNumber
        {
            get { return (int)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
    }
}
