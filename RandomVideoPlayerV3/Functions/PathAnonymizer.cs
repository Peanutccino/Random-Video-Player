using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class PathAnonymizer
    {
        public static string AnonymizeFilePath(string path, string privateFolderName = "privatepath")
        {
            if (string.IsNullOrWhiteSpace(path))
                return path;

            var root = Path.GetPathRoot(path) ?? string.Empty;

            var fileName = Path.GetFileName(path);

            if (string.IsNullOrEmpty(fileName))
            {
                return string.IsNullOrEmpty(root)
                    ? privateFolderName
                    : Path.Combine(root, privateFolderName);
            }

            if (!string.IsNullOrEmpty(root))
                return Path.Combine(root, privateFolderName, fileName);

            return Path.Combine(privateFolderName, fileName);
        }
    }
}
