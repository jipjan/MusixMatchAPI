using Newtonsoft.Json;

namespace MusixMatch_API.APIMethods
{
    public class BaseJson
    {
        public class RootObject
        {
            public Message Message { get; set; }
        }

        public class Message
        {
            public Header Header { get; set; }
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
