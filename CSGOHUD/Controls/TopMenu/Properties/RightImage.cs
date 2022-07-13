using System.Windows;
using System.Windows.Media;

namespace CSGOHUD.Controls.TopMenu
{
    public partial class Game_Panel_Top
    {
        public static readonly DependencyProperty RightImageProperty = DependencyProperty.Register(
            nameof(RightImage),
            typeof(ImageSource),
            typeof(Game_Panel_Top));

        //private static bool LeftImage_Validate(object value)
        //{
        //    ImageSource? currentValue = (ImageSource)value;

        //    if (currentValue == null)
        //        return false;

        //    return false;
        //}

        //private static void LeftImageProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        //{
        //    Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;
        //    game_Panel_Top.LeftImage = (ImageSource)args.NewValue;

        //    //ValueChangedEvent.Invoke((int)args.NewValue);
        //}

        //private static object LeftImageProperty_CoerceValue(DependencyObject dependencyObject, object baseValue)
        //{
        //    Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;

        //    ImageSource? currentValue = (ImageSource)baseValue;

        //    if (currentValue == null)
        //        return new BitmapImage() { UriSource = new Uri("pack://application:,,,/Images/1.png") };

        //    return baseValue;
        //}

        //public delegate void ValueChangedEventHandler(double newValue);
        //public static event ValueChangedEventHandler ValueChangedEvent = new((newValue) => { });

        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }
    }
}
