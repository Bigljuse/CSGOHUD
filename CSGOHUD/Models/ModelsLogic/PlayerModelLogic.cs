using CSGOHUD.Dictionaries;
using CSGOHUD.Models.Enums;
using CSGOHUD.Models.Player.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSGOHUD.Models.Player
{
    public sealed partial class PlayerModel
    {
        public Weapon GetTopWeapon()
        {
            if (Weapons.Count == 0)
                return Weapon.None;

            WeaponModel knife = Weapons.Find(x => x.Type.Contains("Knife", StringComparison.OrdinalIgnoreCase));
            WeaponModel Pistol = Weapons.Find(x => x.Type.Contains("Pistol", StringComparison.OrdinalIgnoreCase));
            WeaponModel MainGun = Weapons.Find(x =>
                x.Type.Contains("Rifle", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Submachine", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Shotgun", StringComparison.OrdinalIgnoreCase) ||
                x.Type.Contains("Machine", StringComparison.OrdinalIgnoreCase));

            if (MainGun != null)
                return WeaponsDictionary.Weapons[MainGun.Name];

            if (Pistol != null)
                return WeaponsDictionary.Weapons[Pistol.Name];

            return WeaponsDictionary.Weapons[knife.Name];
        }

        public List<Grenade> GetGrenades()
        {
            List<Grenade> grenades = new List<Grenade>();
            List<WeaponModel> player_grenades = Weapons.Where(x => x.Type.Contains("Grenade", StringComparison.OrdinalIgnoreCase)).ToList();

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
