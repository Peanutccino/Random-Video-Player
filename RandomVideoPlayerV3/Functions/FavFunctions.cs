using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.Functions
{
    public class FavFunctions
    {
        public static List<string> AddToFavoritesList(string currentFile)
        {
            var favFile = PathHandler.PathToListFolder + @"\Favorites.txt";
            var fromTXT = new List<string>();

            if (File.Exists(favFile))
            {
                fromTXT = File.ReadLines(favFile).ToList();
            }
            if (!fromTXT.Contains(currentFile))
            {
                fromTXT.Add(currentFile);
            }
            File.WriteAllLines(favFile, fromTXT);
            
            return fromTXT;
        }

        public static List<string> DeleteFromFavorites(string currentFile, List<string> tempFavorites)
        {
            string favFile = PathHandler.PathToListFolder + @"\Favorites.txt";

            tempFavorites.Remove(currentFile);

            File.WriteAllLines(favFile, tempFavorites);
            
            return tempFavorites;
        }

        public static bool IsFavoriteMatched(string currentVideo, List<string> tempFavorites, FontAwesome.Sharp.IconButton ctrl)
        {
            if (tempFavorites.Contains(currentVideo))
            {
                ctrl.IconColor = Color.Red;
                return true;
            }
            else
            {
                ctrl.IconColor = Color.Black;
                return false;
            }
        }

        public static void AddFavoriteToFolder(string currentFile)
        {
            if (!Directory.Exists(PathHandler.FileMoveFolderPath))
            {
                MessageBox.Show($"Could not find chosen path to favorites: {PathHandler.FileMoveFolderPath}");
                return;
            }

            string fileName = Path.GetFileName(currentFile);
            string newPath = Path.Combine(PathHandler.FileMoveFolderPath, fileName);

            if (SettingsHandler.FileCopy)
            {
                try
                {
                    File.Copy(currentFile, newPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying the file to selected favorite destination: {ex}");
                    throw;
                }
            }
            else
            {
                try
                {
                    File.Move(currentFile, newPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error moving the file to selected favorite destination: {ex}");
                    throw;
                }
            }
        }
    }
}
