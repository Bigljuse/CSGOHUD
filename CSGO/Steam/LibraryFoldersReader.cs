using CSGO.Models.Steam;
using Microsoft.Win32;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CSGO.Steam
{
    public static class LibraryFoldersReader
    {
        private static string GetFilePathWithLibraries()
        {
            string steamPath = GetSteamPath();
            string steamappsPath = @$"{steamPath}\steamapps";
            string libraryfoldersPath = @$"{steamappsPath}\libraryfolders.vdf";

            return libraryfoldersPath;
        }

        private static string GetSteamPath()
        {
            string steamPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null).ToString() ?? string.Empty;

            return steamPath;
        }

        public static List<LibraryModel> GetLibraries()
        {
            string jsonText = JsonConverter.ConvertToJsonText(GetFilePathWithLibraries());

            JsonNode? jsonNode = JsonNode.Parse(jsonText);
            int foldersCount = jsonNode?.AsObject().Count ?? 0;

            List<LibraryModel> libraries = new List<LibraryModel>();

            for (int folderNumber = 0; folderNumber <= foldersCount; folderNumber++)
            {
                JsonNode? jsonObject = jsonNode[$"{folderNumber}"];
                libraries.Add(jsonObject.Deserialize<LibraryModel>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
            }

            return libraries;
        }
    }
}
