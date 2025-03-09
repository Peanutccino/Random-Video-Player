namespace RandomVideoPlayer.Model
{
    public class AxisData
    {
        public List<String> ScriptFiles;
        public bool HasBackup;
        public bool MovedWithoutLocal;
        public int SelectedIndex;
        public string BackupPath;
        public string LocalPath;

        public AxisData()
        {
            ScriptFiles = new List<string>();
            HasBackup = false;
            MovedWithoutLocal = false;
            SelectedIndex = 0;
            BackupPath = string.Empty;
            LocalPath = string.Empty;
        }
    }
}
