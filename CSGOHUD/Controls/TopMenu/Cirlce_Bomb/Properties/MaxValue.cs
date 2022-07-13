using System.Windows;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(double),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(100.0, new PropertyChangedCallback(MaxValue_PropertyChanged)),
            new ValidateValueCallback(Validate_MaxValue));

        private static bool Validate_MaxValue(object value)
        {
            double? currentValue = (double)value;

            if (currentValue == null)
                return false;

            if (currentValue >= 0)
                return true;

            return false;
        }

        private static void MaxValue_PropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.MaxValue = (double)args.NewValue;
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
    }
}
