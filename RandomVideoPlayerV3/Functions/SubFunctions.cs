using Mpv.NET.Player;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.Functions
{
    public static class SubFunctions
    {
        public static void UpdateSubtitleParameters(MpvPlayer player)
        {
            player.SetSubtitleFont(SettingsHandler.SubtitleFontType);
            player.SetSubtitleSize(SettingsHandler.SubtitleFontSize);
            player.SetSubtitleOutlineSize(SettingsHandler.SubtitleBorderSize);
            player.SetSubtitleColor(SettingsHandler.SubtitleFontColor);
        }
    }
}
