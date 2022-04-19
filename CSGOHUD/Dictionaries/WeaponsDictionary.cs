using CSGOHUD.Models.Enums;
using System.Collections.Generic;

namespace CSGOHUD.Dictionaries
{
    public static class WeaponsDictionary
    {
        public static Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>()
        {
            {"weapon_ak47",Weapon.AK_47},
            {"weapon_aug",Weapon.Aug},
            {"weapon_awp",Weapon.AWP},
            {"weapon_bayonet",Weapon.Bayonet},
            {"weapon_bizon",Weapon.Bizon},
            {"weapon_cz75a",Weapon.Cz75},
            {"weapon_deagle",Weapon.Deagle},
            {"weapon_elite",Weapon.Elite},
            {"weapon_famas",Weapon.Famas},
            {"weapon_fiveseven",Weapon.Fiveseven},
            {"weapon_g3sg1",Weapon.G3sg1},
            {"weapon_galilar",Weapon.Galilar},
            {"weapon_glock",Weapon.Glock},
            {"weapon_hkp2000",Weapon.Hkp2000},
            {"weapon_knife",0},
            {"weapon_knife_butterfly",0},
            {"weapon_knife_falchion",0},
            {"weapon_knife_flip",0},
            {"weapon_knife_karambit",0},
            {"weapon_knife_gut",0},
            {"weapon_knife_push",0},
            {"weapon_knife_ursus",0},
            {"weapon_knife_t",0},
            {"weapon_knife_tactical",0},
            {"weapon_m4a1",Weapon.M4a1},
            {"weapon_m4a1_silencer",Weapon.M4a1_silencer},
            {"weapon_mac10",Weapon.Mac10},
            {"weapon_mag7",Weapon.Mag7},
            {"weapon_mp7",Weapon.Mp7},
            {"weapon_mp5sd",Weapon.None},
            {"weapon_xm1014",Weapon.Xm1014},
            {"weapon_mp9",Weapon.Mp9},
            {"weapon_negev",Weapon.Negev},
            {"weapon_nova",Weapon.Nova},
            {"weapon_p90",Weapon.P90},
            {"weapon_p250",Weapon.P250},
            {"weapon_m249",Weapon.M249},
            {"weapon_revolver",Weapon.Revolver},
            {"weapon_sawedoff",Weapon.Sawedoff},
            {"weapon_scar20",Weapon.Scar20},
            {"weapon_ssg08",Weapon.Ssg08},
            {"weapon_sg556",Weapon.Sg556},
            {"weapon_taser",Weapon.Taser},
            {"weapon_tec9",Weapon.Tec9},
            {"weapon_ump45",Weapon.Ump45},
            {"weapon_usp_silencer",Weapon.Usp_silencer},
        };

        public static Dictionary<string, Grenade> Grenades = new Dictionary<string, Grenade>()
        {
            {"weapon_incgrenade",Grenade.Incgrenade},
            {"weapon_molotov",Grenade.Molotov},
            {"weapon_hegrenade",Grenade.Hegrenade},
            {"weapon_smokegrenade",Grenade.Smokegrenade},
            {"weapon_flashbang",Grenade.Flashbang},
            {"weapon_decoy",Grenade.Decoy},
        };
    }
}
