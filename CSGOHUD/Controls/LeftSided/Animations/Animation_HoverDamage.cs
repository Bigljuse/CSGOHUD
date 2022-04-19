using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.LeftSided
{
    public partial class Player_Panel_Left
    {
        private DoubleAnimation Animation_HoverDamage()
        {
            DoubleAnimation animation_HoverDamage = new DoubleAnimation();
            animation_HoverDamage.Duration = new TimeSpan(0, 0, 0, 0, 400);
            animation_HoverDamage.FillBehavior = FillBehavior.HoldEnd;
            animation_HoverDamage.AutoReverse = true;
            animation_HoverDamage.From = 0;
            animation_HoverDamage.To = 0.9;

            return animation_HoverDamage;
        }

        public void Play_HoverDamage()
        {
            Image_HoverDamage.BeginAnimation(Image.OpacityProperty, Animation_HoverDamage(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
