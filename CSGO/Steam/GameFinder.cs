using CSGO.Models.Steam;

namespace CSGO.Steam
{
    public class GameFinder
    {
        /// <summary>
        /// Возвращает путь к папке игры без \ в конце.
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns></returns>
        public string GetGameFolder(GameID gameID)
        {
            string gamesFolder = GetGamesFolder(gameID);
            string gameFolder = @$"{gamesFolder}\{Games.Dictionary[gameID]}";
            return gameFolder;
        }

        private string GetGamesFolder(GameID gameID)
        {
            List<LibraryModel> libraries = LibraryFoldersReader.GetLibraries();
            LibraryModel? library = libraries.Find(x => x.Apps.Keys.Contains(((int)gameID).ToString()) == true);

            if (library is null)
                return String.Empty;

            string gamesfolder = @$"{library.Path}\steamapps\common";

            return gamesfolder;
        }
    }
}
