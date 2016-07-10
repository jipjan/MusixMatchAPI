using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedTrackingUrl
    {
        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }
        }

        public class Body
        {
            public string Url { get; set; }
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
