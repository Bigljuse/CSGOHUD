namespace CSGOHUD.Controls.TopMenu.Cirlce_Bomb
{
    public partial class Circle_Bomb
    {
        private delegate void _angle_SetedEventHandler();
        private event _angle_SetedEventHandler _angle_Setted = new _angle_SetedEventHandler(() => { });

        public delegate void TimerFinishedEnventHandler();
        public event TimerFinishedEnventHandler TimerFinishedEvent = new TimerFinishedEnventHandler(() => { });
    }
}
