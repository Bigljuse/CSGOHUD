using CSGO.Models;
using CSGO.Models.Overviews;
using CSGO.Models.Steam;
using CSGO.Steam;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CSGO
{
    public static class MapOverviewer
    {
        public static MapOverviewModel GetMap(string mapName)
        {
            string mapPath = GetMapPath(mapName);
            string jsonMapText = JsonConverter.ConvertToJsonText(mapPath);
            JsonNode? jsonNode = JsonNode.Parse(jsonMapText);
            MapOverviewModel mapOverview = jsonNode.Deserialize<MapOverviewModel>();
            return mapOverview;
        }

        public static MapOverviewModel GetMap(MapNames map)
        {
            return GetMap(map.ToString());
        }

        private static string GetMapPath(string mapName)
        {
            GameFinder gameFinder = new GameFinder();
            string gameFolder = gameFinder.GetGameFolder(GameID.CSGO);
            string overviewsFolder = @$"{gameFolder}\csgo\resource\overviews";
            string mapPath = $@"{overviewsFolder}\{mapName}.txt";

            return mapPath;
        }
    }
}
