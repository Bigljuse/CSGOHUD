using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        public static readonly DependencyProperty ProgressFillProperty = DependencyProperty.Register(
            nameof(ProgressFill),
            typeof(Brush),
            typeof(Circle_Bomb),
            new UIPropertyMetadata(
                (Brush)new BrushConverter().ConvertFromString("#FF94FF00"),
                new PropertyChangedCallback(ProgressFill_Changed),
                new CoerceValueCallback(ProgressFill_CoerceValue)),
            new ValidateValueCallback(ProgressFill_Validate));

        private static bool ProgressFill_Validate(object value)
        {
            Brush? brush = (Brush)value;

            if (brush == null)
                return false;

            return true;
        }

        private static void ProgressFill_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;
            circle_Bomb.ProgressFill = (Brush)args.NewValue;
        }

        private static object ProgressFill_CoerceValue(DependencyObject dependencyObject, object baseValue)
        {
            Circle_Bomb circle_Bomb = (Circle_Bomb)dependencyObject;

            Brush currentValue = (Brush)baseValue;

            if (currentValue == null)
                return (Brush)new BrushConverter().ConvertFromString("#FF94FF00");

            return baseValue;
        }

        public Brush ProgressFill
        {
            get { return (Brush)GetValue(ProgressFillProperty); }
            set { SetValue(ProgressFillProperty, value); }
        }
    }
}
