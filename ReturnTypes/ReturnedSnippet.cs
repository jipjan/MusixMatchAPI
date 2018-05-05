using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedSnippet
    {
        public class Snippet
        {
            [JsonProperty("snippet_language")]
            public string SnippetLanguage { get; set; }

            [JsonProperty("restricted")]
            public int Restricted { get; set; }

            [JsonProperty("instrumental")]
            public int Instrumental { get; set; }

            [JsonProperty("snippet_body")]
            public string SnippetBody { get; set; }

            [JsonProperty("script_tracking_url")]
            public string ScriptTrackingUrl { get; set; }

            [JsonProperty("pixel_tracking_url")]
            public string PixelTrackingUrl { get; set; }

            [JsonProperty("html_tracking_url")]
            public string HtmlTrackingUrl { get; set; }

            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }
        }

        public class Body
        {
            public Snippet Snippet { get; set; }
        }

        public class RootObject
        {
            public Message Message { get; set; }
        }

        public class Message
        {
            public Header Header { get; set; }
            public Body Body { get; set; }
        }

        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }
        }
    }
}