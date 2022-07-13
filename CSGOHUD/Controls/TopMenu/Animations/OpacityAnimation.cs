using System;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.TopMenu.Animations
{
    public partial class AnimationOpacity
    {
        public delegate void TimerOpacityChangedEventHandler();
        public event TimerOpacityChangedEventHandler AnimationCompletedEvent = new(() => { });

        public DoubleAnimation Animate(double from, double to)
        {
            DoubleAnimation animation_Opacity = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(500),
                FillBehavior = FillBehavior.HoldEnd,
                From = from,
                To = to
            };
            animation_Opacity.Completed += Animation_Opacity_Completed;
            return animation_Opacity;
        }

        private void Animation_Opacity_Completed(object? sender, EventArgs e)
        {
            AnimationCompletedEvent.Invoke();
        }
    }
}
