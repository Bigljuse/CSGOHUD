using System.Windows;

namespace CSGOHUD.Controls.TopMenu
{
    public partial class Game_Panel_Top
    {
        public static readonly DependencyProperty LeftScoreProperty = DependencyProperty.Register(
            nameof(LeftScore),
            typeof(int),
            typeof(Game_Panel_Top),
            new UIPropertyMetadata(0,
                new PropertyChangedCallback(LeftScoreProperty_Changed),
                new CoerceValueCallback(LeftScoreProperty_CoerceValue)),
            new ValidateValueCallback(LeftScore_Validate));

        private static bool LeftScore_Validate(object value)
        {
            int currentValue = (int)value;

            if (currentValue >= 0)
                return true;

            return false;
        }

        private static void LeftScoreProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;
            game_Panel_Top.LeftScore = (int)args.NewValue;

            //ValueChangedEvent.Invoke((int)args.NewValue);
        }

        private static object LeftScoreProperty_CoerceValue(DependencyObject dependencyObject, object baseValue)
        {
            Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;

            int? currentValue = (int)baseValue;

            if (currentValue == null)
                return 0;

            return currentValue;
        }

        //public delegate void ValueChangedEventHandler(double newValue);
        //public static event ValueChangedEventHandler ValueChangedEvent = new((newValue) => { });

        public int LeftScore
        {
            get { return (int)GetValue(LeftScoreProperty); }
            set { SetValue(LeftScoreProperty, value); }
        }
    }
}
