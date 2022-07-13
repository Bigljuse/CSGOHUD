using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty CircleFrontProperty = DependencyProperty.Register(
            nameof(CircleFront),
            typeof(Brush),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(Brushes.DarkGray, new PropertyChangedCallback(CircleFrontProperty_Changed), new CoerceValueCallback(CircleFrontProperty_CoerceValue)),
            new ValidateValueCallback(CircleFront_Validate));

        private static bool CircleFront_Validate(object value)
        {
            Brush? brush = (Brush)value;

            if (brush == null)
                return false;

            return true;
        }

        private static void CircleFrontProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.CircleFront = (Brush)args.NewValue;
        }

        private static object CircleFrontProperty_CoerceValue(DependencyObject dependencyObject, object baseValue)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;

            Brush currentValue = (Brush)baseValue;

            if (currentValue == null)
                return Brushes.DarkGray;

            return baseValue;
        }

        public Brush CircleFront
        {
            get { return (Brush)GetValue(CircleFrontProperty); }
            set { SetValue(CircleFrontProperty, value); }
        }
    }
}
