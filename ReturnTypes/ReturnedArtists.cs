using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedArtists
    {
        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }

            public int Available { get; set; }
        }

        public class Artist
        {
            [JsonProperty("artist_id")]
            public int ArtistId { get; set; }

            [JsonProperty("artist_mbid")]
            public string ArtistMbid { get; set; }

            [JsonProperty("artist_name")]
            public string ArtistName { get; set; }

            [JsonProperty("artist_alias_list")]
            public List<object> ArtistAliasList { get; set; }

            [JsonProperty("artist_rating")]
            public int ArtistRating { get; set; }

            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }
        }

        public class ArtistList
        {
            public Artist Artist { get; set; }
        }

        public class Body
        {
            [JsonProperty("artist_list")]
            public List<ArtistList> ArtistList { get; set; }
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