using System.Windows;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            nameof(Angle),
            typeof(double),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(0.0, new PropertyChangedCallback(AngleProperty_Changed)),
            new ValidateValueCallback(Angle_Validate));

        private static bool Angle_Validate(object value)
        {
            double? currentValue = (double)value;

            if (currentValue == null)
                return false;

            if (currentValue >= 0)
                return true;

            return false;
        }

        private static void AngleProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.Angle = (double)args.NewValue;
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
    }
}
