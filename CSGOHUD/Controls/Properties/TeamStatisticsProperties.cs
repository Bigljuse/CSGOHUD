using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSGOHUD.Controls
{
    public partial class TeamStatistics
    {
        public static readonly DependencyProperty T_TeamNameProperty = DependencyProperty.Register("T_TeamName", typeof(string), typeof(TeamStatistics), new UIPropertyMetadata("Террористы"));
        public static readonly DependencyProperty CT_TeamNameProperty = DependencyProperty.Register("CT_TeamName", typeof(string), typeof(TeamStatistics), new UIPropertyMetadata("Спецназ"));
        public static readonly DependencyProperty T_RoundsWonProperty = DependencyProperty.Register("T_RoundsWon", typeof(int), typeof(TeamStatistics), new UIPropertyMetadata(0));
        public static readonly DependencyProperty CT_RoundsWonProperty = DependencyProperty.Register("CT_RoundsWon", typeof(int), typeof(TeamStatistics), new UIPropertyMetadata(0));
        public static readonly DependencyProperty TimerProperty = DependencyProperty.Register("Timer", typeof(string), typeof(TeamStatistics), new UIPropertyMetadata("0:00"));
        public static readonly DependencyProperty RoundCounterProperty = DependencyProperty.Register("RoundCounter", typeof(string), typeof(TeamStatistics), new UIPropertyMetadata("Round 0/30"));

        public string T_TeamName
        {
            get { return (string)GetValue(T_TeamNameProperty); }
            set { SetValue(T_TeamNameProperty, value); }
        }

        public string CT_TeamName
        {
            get { return (string)GetValue(CT_TeamNameProperty); }
            set { SetValue(CT_TeamNameProperty, value); }
        }

        public int CT_RoundsWon
        {
            get { return (int)GetValue(CT_RoundsWonProperty); }
            set { SetValue(CT_RoundsWonProperty, value); }
        }

        public int T_RoundsWon
        {
            get { return (int)GetValue(T_RoundsWonProperty); }
            set { SetValue(T_RoundsWonProperty, value); }
        }

        public string Timer
        {
            get { return (string)GetValue(TimerProperty); }
            set { SetValue(TimerProperty, value); }
        }

        public string RoundCounter
        {
            get { return (string)GetValue(RoundCounterProperty); }
            set { SetValue(RoundCounterProperty, value); }
        }
    }
}
