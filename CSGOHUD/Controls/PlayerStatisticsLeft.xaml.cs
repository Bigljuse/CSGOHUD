using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CSGOHUD.Controls
{
    /// <summary>
    /// Interaction logic for PlayerStatistics.xaml
    /// </summary>
    public partial class PlayerStatisticsLeft : UserControl
    {
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(PlayerStatisticsLeft), new UIPropertyMetadata((double)GridLength.Auto.Value));
        
        public static readonly DependencyProperty PlayerAliveProperty =
            DependencyProperty.Register("IsPlayerAlive", typeof(bool), typeof(PlayerStatisticsLeft), new UIPropertyMetadata(false));

        [TypeConverter(typeof(LengthConverter))]
        public double ImageWidth
        {
            get
            {
                return (double)GetValue(ImageWidthProperty);
            }
            set { SetValue(ImageWidthProperty, value); }
        }

        public bool IsPlayerAlive
        {
            get
            {
                return (bool)GetValue(PlayerAliveProperty);
            }
            set { SetValue(PlayerAliveProperty, value); }
        }

        public PlayerStatisticsLeft()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
