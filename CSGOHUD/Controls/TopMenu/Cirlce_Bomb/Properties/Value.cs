using System.Windows;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(double),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(0.0, new PropertyChangedCallback(ValueProperty_Changed)),
            new ValidateValueCallback(Value_Validate));

        private static bool Value_Validate(object value)
        {
            double? currentValue = (double)value;

            if (currentValue == null)
                return false;

            if (currentValue >= 0)
                return true;

            return false;
        }

        private static void ValueProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.Value = (double)args.NewValue;

            ValueChangedEvent.Invoke((double)args.NewValue);
        }

        public delegate void ValueChangedEventHandler(double newValue);
        public static event ValueChangedEventHandler ValueChangedEvent = new((newValue) => { });


        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
