using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.LeftSided
{
    public partial class Player_Panel_Left
    {
        private int _damage = 0;

        private DoubleAnimation Animation_NumberHit()
        {
            DoubleAnimation animation_NumberHit = new DoubleAnimation();
            animation_NumberHit.Duration = new TimeSpan(0, 0, 0, 0, 250);
            animation_NumberHit.FillBehavior = FillBehavior.HoldEnd;
            animation_NumberHit.AutoReverse = true;
            animation_NumberHit.Completed += Animation_NumberHit_Completed;
            animation_NumberHit.From = 27;
            animation_NumberHit.To = 40;

            return animation_NumberHit;
        }

        private DoubleAnimation Animation_NumberHit_Appearance()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = new TimeSpan(0, 0, 0, 0, 100);
            doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
            doubleAnimation.Completed += Animation_NumberHit_Appearance_Completed;
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;

            return doubleAnimation;
        }

        private DoubleAnimation Animation_NumberHit_Seeking()
        {
            DoubleAnimation Animation_NumberHit_Seeking = new DoubleAnimation();
            Animation_NumberHit_Seeking.BeginTime = new TimeSpan(0, 0, 0, 0, 800);
            Animation_NumberHit_Seeking.Duration = new TimeSpan(0, 0, 0, 0, 1000);
            Animation_NumberHit_Seeking.FillBehavior = FillBehavior.HoldEnd;
            Animation_NumberHit_Seeking.From = 1.0;
            Animation_NumberHit_Seeking.To = 0.0;

            return Animation_NumberHit_Seeking;
        }

        private void Animation_NumberHit_Appearance_Completed(object? sender, EventArgs e)
        {
            TextBlock_HitDamage.BeginAnimation(TextBlock.FontSizeProperty, Animation_NumberHit(), HandoffBehavior.SnapshotAndReplace);
        }
        private void Animation_NumberHit_Completed(object? sender, EventArgs e)
        {
            TextBlock_HitDamage.BeginAnimation(TextBlock.OpacityProperty, Animation_NumberHit_Seeking(), HandoffBehavior.SnapshotAndReplace);
        }

        public void Play_NumberHit(int healthBefore, int healthAfter)
        {
            if (_healthbar_Finished == true)
                return;

            if (healthBefore < healthAfter)
                return;

            _damage += healthBefore - healthAfter;

            TextBlock_HitDamage.Text = _damage.ToString();

            TextBlock_HitDamage.BeginAnimation(TextBlock.OpacityProperty, Animation_NumberHit_Appearance(), HandoffBehavior.SnapshotAndReplace);
        }
    }
}
