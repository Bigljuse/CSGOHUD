using CSGOHUD.Controls.TopMenu.Enums;
using System.Windows;

namespace CSGOHUD.Controls.TopMenu
{
    public partial class Game_Panel_Top
    {
        public static readonly DependencyProperty BombPlantedProperty = DependencyProperty.Register(
            nameof(Bomb),
            typeof(BombState),
            typeof(Game_Panel_Top),
            new UIPropertyMetadata(BombState.holded, new PropertyChangedCallback(BombPlantedProperty_Changed)));

        private static void BombPlantedProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Game_Panel_Top game_Panel_Top = (Game_Panel_Top)dependencyObject;
            game_Panel_Top.Bomb = (BombState)args.NewValue;

            if ((BombState)args.NewValue == BombState.planted)
                BombPlantedEvent.Invoke();

            if ((BombState)args.NewValue == BombState.defused)
                BombDefuzedEvent.Invoke();

            if ((BombState)args.NewValue == BombState.holded)
                BombHoldedEvent.Invoke();
        }

        public delegate void BombPlantedEventHandler();
        public static event BombPlantedEventHandler BombPlantedEvent = new(() => { });

        public delegate void BombDefuzedEventHandler();
        public static event BombDefuzedEventHandler BombDefuzedEvent = new(() => { });

        public delegate void BombHoldedEventHandler();
        public static event BombHoldedEventHandler BombHoldedEvent = new(() => { });

        public BombState Bomb
        {
            get { return (BombState)GetValue(BombPlantedProperty); }
            set { SetValue(BombPlantedProperty, value); }
        }
    }
}
