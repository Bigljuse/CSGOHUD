using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.LeftSided
{
    public partial class Player_Panel_Left
    {
        private DoubleAnimation Animation_PlayerSpawned()
        {
            DoubleAnimation animation_PlayerSpawned = new DoubleAnimation();
            animation_PlayerSpawned.Duration = new TimeSpan(0, 0, 0, 0, 200);
            animation_PlayerSpawned.FillBehavior = FillBehavior.HoldEnd;
            animation_PlayerSpawned.From = 230;
            animation_PlayerSpawned.To = 360;

            return animation_PlayerSpawned;
        }

        private void PlayAnimation_PlayerSpawned()
        {
            Panel_Left.Opacity = 1;
            Panel_Left.Background = new BrushConverter().ConvertFromString("#BF060682") as Brush;

            Panel_Left.BeginAnimation(Grid.WidthProperty, Animation_PlayerSpawned(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
