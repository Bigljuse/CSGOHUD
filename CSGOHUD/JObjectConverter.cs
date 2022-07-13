using CSGOHUD.Models.Player.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSGOHUD
{
    public static class JObjectConverter
    {
        public static T ExtractSimpleDataTo<T>(this JObject jObject, in T target) where T : class
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsValueType == false &&
                    property.PropertyType != typeof(string))
                    continue;

                JProperty? jProperty = jObject.Property(property.Name, StringComparison.OrdinalIgnoreCase);

                if (jProperty is null)
                {
                    //object? defaultValue = Convert.ChangeType(null, property.PropertyType);
                    if (property.PropertyType == typeof(string))
                        property.SetValue(target, string.Empty);
                    else
                        property.SetValue(target, null);
                    continue;
                }

                string jPropertyValue = jProperty.Value.ToString();

                if (jPropertyValue.Contains('.') == true)
                {
                    string[] splited = jPropertyValue.Split('.');

                    if (property.PropertyType == typeof(Int32))
                        jPropertyValue = splited[0];

                    if (property.PropertyType == typeof(double))
                    {
                        jPropertyValue = $"{splited[0]},{splited[1]}";
                    }
                }

                object? setValue = Convert.ChangeType(jPropertyValue, property.PropertyType);

                property.SetValue(target, setValue);
            }

            return target;
        }

        public static List<WeaponModel> ExtractPlayerWeapons(JObject jWeapons)
        {
            List<WeaponModel> extractedWeapons = new List<WeaponModel>();

            for (int weaponNumber = 0; weaponNumber <= jWeapons.Count - 1; weaponNumber++)
            {
                JObject jWeapon = jWeapons[$"weapon_{weaponNumber}"] as JObject;

                if (jWeapon == null)
                    return extractedWeapons;

                WeaponModel weapon = jWeapon.ToObject<WeaponModel>();
                extractedWeapons.Add(weapon);
            }

            return extractedWeapons;
        }
    }
}
