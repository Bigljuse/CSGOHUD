using System.Text.RegularExpressions;

namespace CSGO.Steam
{
    public sealed class JsonConverter
    {
        private static string PlaceColonsBetweenPropertyAndValue(string text)
        {
            Regex colonsRegex = new Regex("(?<=\")(\t+)(?=\")|(?<=\")([\r\n]*\t*(?={))");
            return colonsRegex.Replace(text, ": ");
        }

        private static string PlaceCommasAfterPropertiesFields(string text)
        {
            string newText = text;

            Regex commasRegex = new Regex("\t*\".*\".+\".*\"\\s*[\r\n]*(?=\t+[\"\r\n])");
            var mathces = commasRegex.Matches(text);

            foreach (Match match in mathces)
            {
                string matchValue = match.Value.Replace("\r\n",",\r\n");
                newText = newText.Replace(match.Value, matchValue);
            }

            return newText;
        }

        private static string FixEndingOfLines(string text)
        {
            Regex commasRegex = new Regex("\\s*([\r\n]+|\r+)");
            string newText = commasRegex.Replace(text, "\r\n");
            return newText;
        }

        private static string PlaceCommasAfterBracketsInObjects(string text)
        {
            string[] lines = text.Split('\n');
            string newText = text;

            Regex commasRegex = new Regex("(\t+}\n(?=\t+\"))");
            return commasRegex.Replace(text, "},\n");
        }

        private static string ClearFromTrash(string text)
        {
            Regex trashRegex = new Regex("([\r\n]+\t*[\\/]+.+[\r\n])|((?<=\")\t*\\/+.+(?=[\r\n]))");
            return trashRegex.Replace(text, "\r\n");
        }

        private static string GetFirstBrackets(string fileText)
        {
            Regex bracketsRegex = new Regex("{[\\w\\W]+}");
            return bracketsRegex.Match(fileText).Value;
        }

        private static string GetFileText(string filePath)
        {
            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader streamReader = new StreamReader(fileStream);

            return streamReader.ReadToEnd();
        }

        public static string ConvertToJsonText(string filePath)
        {
            if (File.Exists(filePath) == false)
                throw new FileNotFoundException($"Файл по пути: {filePath} не был найден");

            string fileText = GetFileText(filePath);
            fileText = ClearFromTrash(fileText);
            fileText = GetFirstBrackets(fileText);
            fileText = FixEndingOfLines(fileText);
            fileText = PlaceColonsBetweenPropertyAndValue(fileText);
            fileText = PlaceCommasAfterPropertiesFields(fileText);
            fileText = PlaceCommasAfterBracketsInObjects(fileText);

            return fileText;
        }
    }
}
