using CSGOHUD.Models.Enums;
using System;
using System.Collections.Generic;
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

namespace CSGOHUD.Controls.Middle
{
    /// <summary>
    /// Interaction logic for Player_Panel_Middle.xaml
    /// </summary>
    public partial class Player_Panel_Middle : UserControl
    {
        private string default_Image = "pack://application:,,,/Images/T-CT.jpg";

        public Player_Panel_Middle()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Panel_Middle_Loaded(object sender, RoutedEventArgs e)
        {
            if (Show == false)
                Visibility = Visibility.Collapsed;

            //if (String.IsNullOrWhiteSpace(Source))
            //    Source = default_Image;

        }

        public void Grenades_Check(List<Grenade> grenades)
        {
            if (grenades.Count == 3)
                Viewbox_Grenade_4.Visibility = Visibility.Collapsed;
            if (grenades.Count == 2)
            {
                Viewbox_Grenade_3.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_4.Visibility = Visibility.Collapsed;
            }
            if (grenades.Count == 1)
            {
                Viewbox_Grenade_2.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_3.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_4.Visibility = Visibility.Collapsed;
            }
            if (grenades.Count == 0)
            {
                Viewbox_Grenade_1.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_2.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_3.Visibility = Visibility.Collapsed;
                Viewbox_Grenade_4.Visibility = Visibility.Collapsed;
                return;
            }

            for (int grenadeId = 0; grenadeId < grenades.Count; grenadeId++)
            {
                Grenade grenade = grenades[grenadeId];
                if (grenadeId == 0)
                {
                    Viewbox_Grenade_1.Visibility = Visibility.Visible;
                    Path_Grenade_1.Data = Application.Current.Resources[grenade.ToString()] as Geometry;
                }
                if (grenadeId == 1)
                {
                    Viewbox_Grenade_2.Visibility = Visibility.Visible;
                    Path_Grenade_2.Data = Application.Current.Resources[grenade.ToString()] as Geometry;
                }
                if (grenadeId == 2)
                {
                    Viewbox_Grenade_3.Visibility = Visibility.Visible;
                    Path_Grenade_3.Data = Application.Current.Resources[grenade.ToString()] as Geometry;
                }
                if (grenadeId == 3)
                {
                    Viewbox_Grenade_4.Visibility = Visibility.Visible;
                    Path_Grenade_4.Data = Application.Current.Resources[grenade.ToString()] as Geometry;
                }
            }
        }
    }
}
