using CSGO.Models.Player;

namespace CSGO.Dictionaries
{
    public static class WeaponsDictionary
    {
        public static Dictionary<string, WeaponName> Weapons = new Dictionary<string, WeaponName>()
        {
            {"weapon_ak47",WeaponName.AK_47},
            {"weapon_aug",WeaponName.Aug},
            {"weapon_awp",WeaponName.AWP},
            {"weapon_bayonet",WeaponName.Bayonet},
            {"weapon_bizon",WeaponName.Bizon},
            {"weapon_cz75a",WeaponName.Cz75},
            {"weapon_deagle",WeaponName.Deagle},
            {"weapon_elite",WeaponName.Elite},
            {"weapon_famas",WeaponName.Famas},
            {"weapon_fiveseven",WeaponName.Fiveseven},
            {"weapon_g3sg1",WeaponName.G3sg1},
            {"weapon_galilar",WeaponName.Galilar},
            {"weapon_glock",WeaponName.Glock},
            {"weapon_hkp2000",WeaponName.Hkp2000},
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
            {"weapon_m4a1",WeaponName.M4a1},
            {"weapon_m4a1_silencer",WeaponName.M4a1_silencer},
            {"weapon_mac10",WeaponName.Mac10},
            {"weapon_mag7",WeaponName.Mag7},
            {"weapon_mp7",WeaponName.Mp7},
            {"weapon_mp5sd",WeaponName.None},
            {"weapon_xm1014",WeaponName.Xm1014},
            {"weapon_mp9",WeaponName.Mp9},
            {"weapon_negev",WeaponName.Negev},
            {"weapon_nova",WeaponName.Nova},
            {"weapon_p90",WeaponName.P90},
            {"weapon_p250",WeaponName.P250},
            {"weapon_m249",WeaponName.M249},
            {"weapon_revolver",WeaponName.Revolver},
            {"weapon_sawedoff",WeaponName.Sawedoff},
            {"weapon_scar20",WeaponName.Scar20},
            {"weapon_ssg08",WeaponName.Ssg08},
            {"weapon_sg556",WeaponName.Sg556},
            {"weapon_taser",WeaponName.Taser},
            {"weapon_tec9",WeaponName.Tec9},
            {"weapon_ump45",WeaponName.Ump45},
            {"weapon_usp_silencer",WeaponName.Usp_silencer},
        };

        public static Dictionary<string, GrenadeName> Grenades = new Dictionary<string, GrenadeName>()
        {
            {"weapon_incgrenade",GrenadeName.Incgrenade},
            {"weapon_molotov",GrenadeName.Molotov},
            {"weapon_hegrenade",GrenadeName.Hegrenade},
            {"weapon_smokegrenade",GrenadeName.Smokegrenade},
            {"weapon_flashbang",GrenadeName.Flashbang},
            {"weapon_decoy",GrenadeName.Decoy},
        };
    }
}
