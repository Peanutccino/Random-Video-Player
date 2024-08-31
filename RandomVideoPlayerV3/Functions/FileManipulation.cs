
namespace RandomVideoPlayer.Functions
{
    public class FileManipulation
    {
        /// <summary>
        /// Take a filepath and changes the extension to a chosen one
        /// </summary>
        /// <param name="originalFilePath">String with full filepath</param>
        /// <param name="newExtension">Extension to replace the original with</param>
        /// <returns>Original filepath with selected extension instead of original</returns>
        public static string GetFilePathWithDifferentExtension(string originalFilePath, string newExtension)
        {
            string directory = Path.GetDirectoryName(originalFilePath);

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);

            string newFilePath = Path.Combine(directory, fileNameWithoutExtension + newExtension);

            return newFilePath;
        }
        /// <summary>
        /// Searches for available .funscript variants of the provided file
        /// </summary>
        /// <param name="originalFilePath">String with full filepath</param>
        /// <returns>List with all found funscripts</returns>
        public static List<string> GetAssociatedFunscripts(string originalFilePath)
        {
            var funscriptList = new List<string>();
            var filePathWithoutExtension = Path.Combine(Path.GetDirectoryName(originalFilePath), Path.GetFileNameWithoutExtension(originalFilePath));

            var suffixes = new string[] { "", ".pitch", ".roll", ".surge", ".sway", ".twist" };

            foreach (var suffix in suffixes)
            {
                string fullFileName = $"{filePathWithoutExtension}{suffix}.funscript";
                if (File.Exists(fullFileName))
                {
                    funscriptList.Add(fullFileName);
                }
            }
            return funscriptList;
        }
        /// <summary>
        /// Get directory path from a string
        /// </summary>
        /// <param name="filePath">String with full filepath</param>
        /// <returns>Path to directory that holds the file</returns>
        public static string GetFileDirectory(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);

            if (string.IsNullOrWhiteSpace(directory)) return "";
            return directory;
        }
        /// <summary>
        /// Get Filename with extension from a string
        /// </summary>
        /// <param name="filePath">String with full filepath</param>
        /// <returns>Filename with extension without path</returns>
        public static string GetFileName(string filePath)
        {
            string fileName = Path.GetFileName(filePath);

            if (string.IsNullOrWhiteSpace(fileName)) return "";
            return fileName;
        }
        /// <summary>
        /// Trim string to length and optionally add string at the end (e.g. "...")
        /// </summary>
        /// <param name="text">String to trim</param>
        /// <param name="length">Trim to length</param>
        /// <param name="end">Add string to end of trimmed string</param>
        /// <returns>Trimmed text</returns>
        public static string TrimText(string text, int length, string end)
        {
            int maxLength = length; // Maximum text length.
            string truncatedText = text.Length <= maxLength ? text : text.Substring(0, maxLength) + end;

            return truncatedText;
        }

        public static int CountRowsInFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            int numberOfRows = File.ReadAllLines(filePath).Length;

            return numberOfRows; 
        }

        public static async Task CopyFileAsync(string sourceFilePath, string destinationFilePath)
        {
            await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath, true));
        }

        public static async Task MoveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            await Task.Run(() => File.Move(sourceFilePath, destinationFilePath, true));
        }

    }
}
