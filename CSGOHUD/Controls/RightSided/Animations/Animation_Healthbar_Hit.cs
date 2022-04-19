using System;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CSGOHUD.Controls.RightSided
{
    public partial class Player_Panel_Right
    {
        private bool _healthbar_Finished = false;

        private DoubleAnimation Animation_Healthbar_Background()
        {
            DoubleAnimation animation_Healthbar_Background = new DoubleAnimation();
            animation_Healthbar_Background.BeginTime = new TimeSpan(0, 0, 0, 0, 200);
            animation_Healthbar_Background.Duration = new TimeSpan(0, 0, 0, 0, 300);
            animation_Healthbar_Background.FillBehavior = FillBehavior.HoldEnd;
            animation_Healthbar_Background.From = Rectangle_Background_Health.Width;
            animation_Healthbar_Background.To = Rectangle_Foreground_Health.Width;
            animation_Healthbar_Background.Completed += Animation_Healthbar_Background_Completed;

            return animation_Healthbar_Background;
        }

        private void Animation_Healthbar_Background_Completed(object? sender, EventArgs e)
        {
            _damage = 0;
        }

        private DoubleAnimation Animation_Healthbar_Foreground(double number)
        {
            DoubleAnimation animation_Healthbar_Foreground = new DoubleAnimation();
            animation_Healthbar_Foreground.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
            animation_Healthbar_Foreground.Duration = new TimeSpan(0, 0, 0, 0, 300);
            animation_Healthbar_Foreground.FillBehavior = FillBehavior.HoldEnd;
            animation_Healthbar_Foreground.Completed += Animation_Healthbar_Foreground_Completed;
            animation_Healthbar_Foreground.From = Rectangle_Foreground_Health.Width;
            animation_Healthbar_Foreground.To = number;

            return animation_Healthbar_Foreground;
        }

        private void Animation_Healthbar_Foreground_Completed(object? sender, EventArgs e)
        {
            Rectangle_Background_Health.BeginAnimation(Rectangle.WidthProperty, Animation_Healthbar_Background(), HandoffBehavior.SnapshotAndReplace);
        }

        private void Play_Respawn()
        {
            _healthbar_Finished = false;

            DoubleAnimation spawnAnimation = new DoubleAnimation();
            spawnAnimation.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
            spawnAnimation.Duration = new TimeSpan(0, 0, 0, 0, 300);
            spawnAnimation.FillBehavior = FillBehavior.HoldEnd;
            spawnAnimation.From = Rectangle_Foreground_Health.Width;
            spawnAnimation.To = Rectangle_Foreground_Health.MaxWidth;

            Rectangle_Foreground_Health.BeginAnimation(Rectangle.WidthProperty, spawnAnimation, HandoffBehavior.SnapshotAndReplace);
        }

        private void Play_Hit()
        {
            if (_healthbar_Finished == true)
                return;

            double damage = (Rectangle_Foreground_Health.MaxWidth * (Health * 0.01));

            if (damage == 0)
            {
                _healthbar_Finished = true;

                if (Rectangle_Foreground_Health.Width < 1)
                    return;

                DoubleAnimation finishingAnimation = Animation_Healthbar_Foreground(damage);
                finishingAnimation.By = null;
                finishingAnimation.From = Rectangle_Foreground_Health.Width;
                finishingAnimation.To = 0;

                Rectangle_Foreground_Health.BeginAnimation(Rectangle.WidthProperty, finishingAnimation, HandoffBehavior.Compose);
                return;
            }
                        
            Rectangle_Foreground_Health.BeginAnimation(Rectangle.WidthProperty, Animation_Healthbar_Foreground(damage), HandoffBehavior.Compose);
        }
    }
}
