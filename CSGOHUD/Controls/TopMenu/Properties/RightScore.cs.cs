using System.Windows;

namespace CSGOHUD.Controls.TopMenu
{
    public partial class Game_Panel_Top
    {
        public static readonly DependencyProperty RoundProperty = DependencyProperty.Register(
            nameof(RightScore),
            typeof(int),
            typeof(Game_Panel_Top),
            new UIPropertyMetadata(0,
                new PropertyChangedCallback(RoundProperty_Changed),
                new CoerceValueCallback(RoundProperty_CoerceValue)));

        private static void RoundProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;
            game_Panel_Top.RightScore = (int)args.NewValue;
        }

        private static object RoundProperty_CoerceValue(DependencyObject dependencyObject, object baseValue)
        {
            Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;

            int? currentValue = (int)baseValue;

            if (currentValue == null)
                return 0;

            return currentValue;
        }

        public int RightScore
        {
            get { return (int)GetValue(RoundProperty); }
            set { SetValue(RoundProperty, value); }
        }
    }
}
