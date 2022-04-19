using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.LeftSided
{
    public partial class Player_Panel_Left
    {
        private DoubleAnimation Animation_PlayerDied()
        {
            DoubleAnimation animation_PlayerDied = new DoubleAnimation();
            animation_PlayerDied.Duration = new TimeSpan(0, 0, 0, 0, 200);
            animation_PlayerDied.FillBehavior = FillBehavior.HoldEnd;
            animation_PlayerDied.From = 360;
            animation_PlayerDied.To = 230;

            return animation_PlayerDied;
        }

        private void PlayAnimation_PlayerDied()
        {
            Panel_Left.Opacity = 0.3;
            Panel_Left.Background = new BrushConverter().ConvertFromString("#FF020239") as Brush;

            Panel_Left.BeginAnimation(UserControl.WidthProperty, Animation_PlayerDied(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
