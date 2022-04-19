using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace CSGOHUD
{
    public static class JObjectConverter
    {
        public static T ConvertToType<T>(this JObject jObject, in T type) where T : class
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.Name.Contains("int", StringComparison.CurrentCultureIgnoreCase) == false &&
                    property.PropertyType.Name.Contains("bool", StringComparison.CurrentCultureIgnoreCase) == false &&
                    property.PropertyType.Name.Contains("string", StringComparison.CurrentCultureIgnoreCase) == false)
                    continue;

                JProperty? jProperty = jObject.Property(property.Name, StringComparison.OrdinalIgnoreCase);

                if (jProperty is null)
                    continue;

                string jPropertyValue = jProperty.Value.ToString();

                object? setValue = Convert.ChangeType(jPropertyValue, property.PropertyType);

                property.SetValue(type, setValue);
            }

            return type;
        }
    }
}
