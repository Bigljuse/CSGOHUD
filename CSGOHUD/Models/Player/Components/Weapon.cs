namespace CSGOHUD.Models.Player.Components
{
    public sealed class WeaponModel
    {
        public string Name { get; set; } = string.Empty;

        public string PaintKit { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Ammo_Clip { get; set; } = 0;

        public int Ammo_Clip_max { get; set; } = 0;

        public int Ammo_Reserve { get; set; } = 0;

        public string State { get; set; } = string.Empty;
    }
}
