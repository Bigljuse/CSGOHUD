using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty CirlceBackgroundProperty = DependencyProperty.Register(
            nameof(CircleBackground),
            typeof(Brush),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(Brushes.DarkGray, new PropertyChangedCallback(CircleBackgroundProperty_Changed), new CoerceValueCallback(CircleBackgroundProperty_CoerceValue)),
            new ValidateValueCallback(CircleBackground_Validate));

        private static bool CircleBackground_Validate(object value)
        {
            Brush? brush = (Brush)value;

            if (brush == null)
                return false;

            return true;
        }

        private static void CircleBackgroundProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.CircleBackground = (Brush)args.NewValue;
        }

        private static object CircleBackgroundProperty_CoerceValue(DependencyObject dependencyObject, object baseValue)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;

            Brush currentValue = (Brush)baseValue;

            if (currentValue == null)
                return Brushes.DarkGray;

            return baseValue;
        }

        public Brush CircleBackground
        {
            get { return (Brush)GetValue(CirlceBackgroundProperty); }
            set { SetValue(CirlceBackgroundProperty, value); }
        }
    }
}
