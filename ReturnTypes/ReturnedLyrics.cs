using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedLyrics
    {
        public class Lyrics
        {
            [JsonProperty("lyrics_id")]
            public int LyricsId { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("instrumental")]
            public int Instrumental { get; set; }

            [JsonProperty("lyrics_body")]
            public string LyricsBody { get; set; }

            [JsonProperty("lyrics_language")]
            public string LyricsLanguage { get; set; }

            [JsonProperty("script_tracking_url")]
            public string ScriptTrackingUrl { get; set; }

            [JsonProperty("pixel_tracking_url")]
            public string PixelTrackingUrl { get; set; }

            [JsonProperty("html_tracking_url")]
            public string HtmlTrackingUrl { get; set; }

            [JsonProperty("lyrics_copyright")]
            public string LyricsCopyright { get; set; }

            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }
        }

        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }
        }

        public class Body
        {
            public Lyrics Lyrics { get; set; }
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
