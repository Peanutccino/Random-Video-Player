using Mpv.NET.Player;
using Newtonsoft.Json;

namespace RandomVideoPlayer.Model
{
    public static class TrackInfo
    {
        public static List<string> Subtitles { get; set; } = new List<string>();
        public static List<string> AudioTracks { get; set; } = new List<string>();

        public static void GrabTrackInfo(MpvPlayer player)
        {
            string trackInfo = player.TrackInfo();
            Subtitles.Clear();
            AudioTracks.Clear();

            List<Track> tracks = JsonConvert.DeserializeObject<List<Track>>(trackInfo);
            Dictionary<string, string> languageMap = LanguageCodesISO639.LanguageMap;

            foreach (var track in tracks)
            {
                if (track.type == "sub")
                {
                    string languageName;
                    if (!string.IsNullOrEmpty(track.lang))
                    {
                        languageName = languageMap.ContainsKey(track.lang) ? languageMap[track.lang] : track.lang;
                    }
                    else
                    {
                        languageName = $"Subtitle {track.id}";
                    }

                    string subtitleInfo = !string.IsNullOrEmpty(track.title) ? $"{languageName} / {track.title}" : languageName;
                    Subtitles.Add(subtitleInfo);
                }
                else if (track.type == "audio")
                {
                    string languageName = !string.IsNullOrEmpty(track.lang) && languageMap.ContainsKey(track.lang) ? languageMap[track.lang] : null;
                    string title = !string.IsNullOrEmpty(track.title) ? track.title : null;
                    string codec = !string.IsNullOrEmpty(track.codec) ? track.codec.ToUpper() : "";
                    string samplerate = track.demux_samplerate > 0 ? $"{track.demux_samplerate / 1000.0}KHz" : "";
                    string channels = track.demux_channel_count > 0 ? $"{track.demux_channel_count} chn" : "";

                    string audioInfo = $"{(languageName != null ? $"{languageName} " : "")}{(title != null ? $", {title} " : "")}(Audio {track.id}) ({codec}, {samplerate}, {channels})";
                    AudioTracks.Add(audioInfo);
                }
            }
        }
    }
}
