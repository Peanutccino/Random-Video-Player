using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.Functions
{
    public class FavFunctions
    {
        public static List<string> AddToFavorites(string currentFile)
        {
            var favFile = PathHandler.FolderList + @"\Favorites.txt";
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
            string favFile = PathHandler.FolderList + @"\Favorites.txt";

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
    }
}
