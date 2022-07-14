using CSGO.Models.Enums;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CSGOHUD.Controls.LeftSided
{
    /// <summary>
    /// Interaction logic for PlayerStatistics.xaml
    /// </summary>
    public partial class Player_Panel_Left : UserControl
    {
        private readonly List<Viewbox> _grenades_boxes = new List<Viewbox>();

        public Player_Panel_Left()
        {
            DataContext = this;
            InitializeComponent();
            PlayerDied += Died;
            PlayerSpawned += Spawned;
        }
        private void Spawned()
        {
            if (ArmorHead == true)
                Viewbox_ArmorHead.Visibility = Visibility.Visible;
            if (ArmorBody > 0)
                Viewbox_ArmorBody.Visibility = Visibility.Visible;
            if (Defuzer == true)
                Viewbox_Defuzer.Visibility = Visibility.Visible;
            if (C4 == true)
                Viewbox_C4.Visibility = Visibility.Visible;

            Viewbox_Player_Weapon.Visibility = Visibility.Visible;
            TextBlock_Player_Health.Visibility = Visibility.Visible;
            StackPanel_Granades.Visibility = Visibility.Visible;

            PlayAnimation_PlayerSpawned();
            Play_Respawn();
        }

        private void Died()
        {
            Viewbox_ArmorHead.Visibility = Visibility.Collapsed;
            Viewbox_ArmorBody.Visibility = Visibility.Collapsed;
            Viewbox_Defuzer.Visibility = Visibility.Collapsed;
            Viewbox_C4.Visibility = Visibility.Collapsed;
            Viewbox_Player_Weapon.Visibility = Visibility.Collapsed;
            TextBlock_Player_Health.Visibility = Visibility.Collapsed;
            StackPanel_Granades.Visibility = Visibility.Collapsed;
            Image_HoverSelection.Visibility = Visibility.Collapsed;

            TextBlock_HitDamage.Text = "0";
            PlayAnimation_PlayerDied();
        }

        private void Panel_Left_Loaded(object sender, RoutedEventArgs e)
        {
            if (Dead == true)
            {
                Health = 0;
                TextBlock_HitDamage.Text = "0";
                PlayAnimation_PlayerDied();
            }
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
