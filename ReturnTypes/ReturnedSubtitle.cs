using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedSubtitle
    {
        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }
        }

        public class Subtitle
        {
            [JsonProperty("subtitle_id")]
            public int SubtitleId { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("subtitle_body")]
            public string SubtitleBody { get; set; }

            [JsonProperty("subtitle_language")]
            public object SubtitleLanguage { get; set; }

            [JsonProperty("script_tracking_url")]
            public string ScriptTrackingUrl { get; set; }

            [JsonProperty("pixel_tracking_url")]
            public string PixelTrackingUrl { get; set; }

            [JsonProperty("html_tracking_url")]
            public string HtmlTrackingUrl { get; set; }

            [JsonProperty("lyrics_copyright")]
            public string LyricsCopyright { get; set; }
        }

        public class Body
        {
            public Subtitle Subtitle { get; set; }
        }

        public class Message
        {
            public Header Header { get; set; }
            public Body Body { get; set; }
        }

        public class RootObject
        {
            public Message Message { get; set; }
        }
    }
}
