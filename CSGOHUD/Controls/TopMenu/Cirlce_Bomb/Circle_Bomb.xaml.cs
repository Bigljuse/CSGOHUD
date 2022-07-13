using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    /// <summary>
    /// Interaction logic for Player_Panel_Top.xaml
    /// </summary>
    public partial class Circle_Bomb : UserControl
    {
        private Timer _bomb_Timer = new Timer() { Interval = 1000 };
        private int _bomb_flashing_duration = 500;
        private bool _bomb_Stopped = true;

        private enum Border_Half
        {
            Left,
            Right
        }

        public Circle_Bomb()
        {
            InitializeComponent();

            ValueChangedEvent += ValueChanged;
            _bomb_Timer.Elapsed += _bomb_Timer_Elapsed;
        }

        public void Start_BombTimer(double startValue, double maxValue)
        {
            _bomb_Timer.Stop();

            _bomb_flashing_duration = 500;
            Value = startValue;
            MaxValue = maxValue;
            Apply_Value();

            _bomb_Timer.Start();
            _bomb_Stopped = false;
            Start_Animation_Bomb_flashing(_bomb_flashing_duration);
        }

        public void Stop_BombTimer()
        {
            Viewbox_Bomb.BeginAnimation(Viewbox.OpacityProperty, null);
            _bomb_Timer.Stop();
            _bomb_Stopped = true;
        }

        private void Start_Animation_Bomb_flashing(int milliseconds)
        {
            DoubleAnimation animation_BombFlashing = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                AutoReverse = true,
                FillBehavior = FillBehavior.HoldEnd,
                From = 1,
                To = 0.3
            };

            animation_BombFlashing.Completed += (sender, e) =>
            {
                if (_bomb_Stopped == false)
                    Start_Animation_Bomb_flashing(_bomb_flashing_duration);
            };

            Viewbox_Bomb.BeginAnimation(Viewbox.OpacityProperty, animation_BombFlashing, HandoffBehavior.SnapshotAndReplace);
        }

        private void ValueChanged(double newValue) => Apply_Value();

        private void Apply_Value()
        {
            double angle = 360 * Value / MaxValue;
            SetValue(AngleProperty, angle);
            Apply_Angle();
        }

        private void Apply_Angle()
        {
            if (Angle > 180)
            {
                _angle_Setted += Set_NewAngle_Left;
                Set_NewAngle(Border_Half.Right);
            }
            else
            {
                _angle_Setted += Set_NewAngle_Right;
                Set_NewAngle(Border_Half.Left);
            }
        }

        private void Set_NewAngle_Right() => Set_NewAngle(Border_Half.Right);

        private void Set_NewAngle_Left() => Set_NewAngle(Border_Half.Left);

        private void Set_NewAngle(Border_Half side)
        {
            Border cirlce = side == Border_Half.Left ? Border_Half_left : Border_Half_Right;
            double angle = 0;
            double maxAngle = 360;
            double minAngle = 0;
            double milliseconds = 1000;

            if (side == Border_Half.Left)
            {
                maxAngle = 360;
                minAngle = 180;

                if (Angle >= maxAngle)
                    angle = maxAngle;
                else if (Angle <= minAngle)
                    angle = minAngle;
                else
                    angle = Angle;

                milliseconds = Math.Abs(((RotateTransform)cirlce.RenderTransform).Angle - angle) / 0.36;
            }
            else if (side == Border_Half.Right)
            {
                maxAngle = 180;
                minAngle = 0;

                if (Angle >= maxAngle)
                    angle = maxAngle;
                else if (Angle <= minAngle)
                    angle = minAngle;
                else
                    angle = Angle;

                milliseconds = Math.Abs(((RotateTransform)cirlce.RenderTransform).Angle - angle) / 0.36;
            }

            DoubleAnimation animation_NewAngle = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                From = ((RotateTransform)cirlce.RenderTransform).Angle,
                To = angle
            };
            animation_NewAngle.Completed += Animation_NewAngle_Completed;

            ((RotateTransform)cirlce.RenderTransform).BeginAnimation(RotateTransform.AngleProperty, animation_NewAngle, HandoffBehavior.Compose);
        }

        private void Animation_NewAngle_Completed(object? sender, EventArgs e)
        {
            if (Angle < 180)
                Border_Half_left.Visibility = Visibility.Collapsed;
            else if (Angle == 180)
                Border_Half_left.Visibility = Visibility.Collapsed;
            else if (Angle > 180)
                Border_Half_left.Visibility = Visibility.Visible;

            _angle_Setted.Invoke();
            _angle_Setted = new _angle_SetedEventHandler(() => { });
        }

        private void _bomb_Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Value < MaxValue)
                {
                    Value++;
                    _bomb_flashing_duration = 500 - (450 * (int)Value / (int)MaxValue);
                }
                else
                {
                    Stop_BombTimer();
                    TimerFinishedEvent.Invoke();
                }
            });
        }
    }
}
