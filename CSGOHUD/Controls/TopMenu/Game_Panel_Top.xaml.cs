using CSGOHUD.Controls.TopMenu.Animations;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

using Settings = CSGOHUD.Properties.Settings;

namespace CSGOHUD.Controls.TopMenu
{
    /// <summary>
    /// Interaction logic for Game_Panel_Top.xaml
    /// </summary>
    public partial class Game_Panel_Top : UserControl
    {
        private Timer _timer_Round = new Timer() { Interval = 1000 };
        private double _timer = 0;
        private TimerType _current_Timer = TimerType.Timer;

        private enum TimerType
        {
            BombTimer,
            Timer
        }

        public Game_Panel_Top()
        {
            InitializeComponent();
        }

        public void Start_Timer(double seconds)
        {
            _timer = seconds;
            Show_Timer(TimerType.Timer);
            Set_Timer_Text(seconds);
            _timer_Round.Start();
        }

        public void Stop_Timer()
        {

        }

        public void Set_RoundText(int round, int rounds_max)
        {
            TextBlock_Rounds_Counter.Text = $"Round {round} / {rounds_max}";
        }

        private void Panel_Top_Loaded(object sender, RoutedEventArgs e)
        {
            BombPlantedEvent += BombPlanted;
            BombHoldedEvent += BombHolded;
            BombDefuzedEvent += BombDefuzed;
            //BombE += BombPlanted;
            Bomb_Timer.TimerFinishedEvent += Bomb_Timer_TimerFinishedEvent;
            _timer_Round.Elapsed += _timer_Round_Elapsed;
        }

        private void _timer_Round_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_timer <= 0)
                {
                    _timer_Round.Stop();
                    return;
                }

                Set_Timer_Text(--_timer);
            });
        }

        private void Bomb_Timer_TimerFinishedEvent()
        {
            //Show_Timer(TimerType.Timer);
            Bomb = Enums.BombState.exploded;
        }

        private void BombPlanted()
        {
            Bomb_Timer.ProgressFill = new BrushConverter().ConvertFromString("#FFFB2860") as Brush;
            Show_Timer(TimerType.BombTimer);
        }

        private void BombHolded()
        {
            Show_Timer(TimerType.Timer);
        }

        private void BombDefuzed()
        {
            Bomb_Timer.Stop_BombTimer();
            Bomb_Timer.Value = Bomb_Timer.MaxValue;
            Bomb_Timer.ProgressFill = new BrushConverter().ConvertFromString("#FF94FF00") as Brush;
        }

        private void Show_Timer(TimerType timer)
        {
            if (_current_Timer == timer)
                return;

            AnimationOpacity animation_Hiding = new AnimationOpacity();
            AnimationOpacity animation_Showing = new AnimationOpacity();

            if (timer == TimerType.BombTimer)
            {
                _current_Timer = timer;
                animation_Hiding.AnimationCompletedEvent += () =>
                {
                    animation_Showing.AnimationCompletedEvent +=
                    () => { Bomb_Timer.Start_BombTimer(Settings.Default.BombTimerStart, Settings.Default.BombTimerMax); };
                    Bomb_Timer.BeginAnimation(OpacityProperty, animation_Showing.Animate(0, 1), HandoffBehavior.SnapshotAndReplace);
                };

                Grid_Timer.BeginAnimation(OpacityProperty, animation_Hiding.Animate(1, 0), HandoffBehavior.SnapshotAndReplace);
            }

            if (timer == TimerType.Timer)
            {
                _current_Timer = timer;
                animation_Hiding.AnimationCompletedEvent += () =>
                {
                    animation_Showing.AnimationCompletedEvent += () => { Bomb_Timer.Stop_BombTimer(); };
                    Grid_Timer.BeginAnimation(OpacityProperty, animation_Showing.Animate(0, 1), HandoffBehavior.SnapshotAndReplace);
                };

                Bomb_Timer.BeginAnimation(OpacityProperty, animation_Hiding.Animate(1, 0), HandoffBehavior.SnapshotAndReplace);
            }
        }

        public void Set_Timer_Text(double seconds)
        {
            double sec = seconds % 60;
            double min = seconds / 60;

            if (sec > 9)
                TextBlock_Timer.Text = $"{min}:{sec}";
            else
                TextBlock_Timer.Text = $"{min}:0{sec}";
        }
    }
}
