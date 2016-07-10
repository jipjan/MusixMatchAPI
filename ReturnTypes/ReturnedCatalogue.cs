using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class ReturnedCatalogue
    {
        public class Header
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("execute_time")]
            public double ExecuteTime { get; set; }
        }

        public class UrlList
        {
            public string Url { get; set; }
        }

        public class CatalogueTracks
        {
            [JsonProperty("url_list")]
            public List<UrlList> UrlList { get; set; }
        }

        public class UrlList2
        {
            public string Url { get; set; }
        }

        public class CatalogueCommontracks
        {
            [JsonProperty("url_list")]
            public List<UrlList2> UrlList { get; set; }
        }

        public class UrlList3
        {
            public string Url { get; set; }
        }

        public class CatalogueMusicbrainzTracks
        {
            [JsonProperty("url_list")]
            public List<UrlList3> UrlList { get; set; }
        }

        public class Catalogue
        {
            [JsonProperty("updated_time")]
            public string UpdatedTime { get; set; }

            [JsonProperty("catalogue_tracks")]
            public CatalogueTracks CatalogueTracks { get; set; }

            [JsonProperty("catalogue_commontracks")]
            public CatalogueCommontracks CatalogueCommontracks { get; set; }

            [JsonProperty("catalogue_musicbrainz_tracks")]
            public CatalogueMusicbrainzTracks CatalogueMusicbrainzTracks { get; set; }
        }

        public class Body
        {
            public Catalogue Catalogue { get; set; }
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
