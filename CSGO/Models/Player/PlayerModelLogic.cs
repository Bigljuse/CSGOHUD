using CSGO.Dictionaries;

namespace CSGO.Models.Player
{
    public sealed partial class PlayerModel
    {
        public WeaponName GetTopWeapon()
        {
            if (Weapons.Count == 0)
                return WeaponName.None;

            WeaponModel? knife = Weapons.Values.Where(x => x.Type.Contains("Knife", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            WeaponModel? Pistol = Weapons.Values.Where(x => x.Type.Contains("Pistol", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            WeaponModel? MainGun = Weapons.Values.Where(x =>
                x.Type.Contains("Rifle", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Submachine", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Shotgun", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Machine", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (MainGun != null)
                return WeaponsDictionary.Weapons[MainGun.Name];

            if (Pistol != null)
                return WeaponsDictionary.Weapons[Pistol.Name];

            return WeaponsDictionary.Weapons[knife.Name];
        }

        public List<GrenadeName> GetGrenades()
        {
            List<GrenadeName> grenades = new List<GrenadeName>();
            List<WeaponModel> player_grenades = Weapons.Values.Where(x => x.Type.Contains("Grenade", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (WeaponModel grenade in player_grenades)
                grenades.Add(WeaponsDictionary.Grenades[grenade.Name]);

            return grenades;
        }

        public PlayerTeam GetTeam()
        {
            if (Team == "CT")
                return PlayerTeam.CT;

            if (Team == "T")
                return PlayerTeam.T;

            if (string.IsNullOrWhiteSpace(Team))
                return PlayerTeam.None;

            return PlayerTeam.None;
        }
    }
}
