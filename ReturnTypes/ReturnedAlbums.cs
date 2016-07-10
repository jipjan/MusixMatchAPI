using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedAlbums
    {
        public class AlbumList
        {
            public Album Album { get; set; }
        }

        public class Body
        {
            [JsonProperty("album_list")]
            public List<AlbumList> AlbumList { get; set; }
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

            public int Available { get; set; }
        }
    }
}
