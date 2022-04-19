using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.RightSided
{
    public partial class Player_Panel_Right
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
            Panel_Right.Opacity = 1;
            Panel_Right.Background = new BrushConverter().ConvertFromString("#BF060682") as Brush;

            Panel_Right.BeginAnimation(Grid.WidthProperty, Animation_PlayerSpawned(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
