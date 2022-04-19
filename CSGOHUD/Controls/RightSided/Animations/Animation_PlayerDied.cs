using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.RightSided
{
    public partial class Player_Panel_Right
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
            Panel_Right.Opacity = 0.3;
            Panel_Right.Background = new BrushConverter().ConvertFromString("#FF020239") as Brush;

            Panel_Right.BeginAnimation(UserControl.WidthProperty, Animation_PlayerDied(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
