using Newtonsoft.Json;

namespace RandomVideoPlayer.Model
{
    public class Track
    {
        public int id { get; set; }
        public string type { get; set; }
        public int src_id { get; set; }
        public string lang { get; set; }
        public string title { get; set; }
        public int audio_channels { get; set; }
        public string codec { get; set; }

        [JsonProperty("demux-samplerate")]
        public int demux_samplerate { get; set; }
        [JsonProperty("demux-channel-count")]
        public int demux_channel_count { get; set; }
    }
}
