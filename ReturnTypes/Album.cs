using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class Album
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("album_mbid")]
        public string AlbumMbid { get; set; }

        [JsonProperty("album_name")]
        public string AlbumName { get; set; }

        [JsonProperty("album_rating")]
        public int AlbumRating { get; set; }

        [JsonProperty("album_track_count")]
        public int AlbumTrackCount { get; set; }

        [JsonProperty("album_release_date")]
        public string AlbumReleaseDate { get; set; }

        [JsonProperty("album_release_type")]
        public string AlbumReleaseType { get; set; }

        [JsonProperty("artist_id")]
        public int ArtistId { get; set; }

        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }

        [JsonProperty("primary_genres")]
        public PrimaryGenres PrimaryGenres { get; set; }

        [JsonProperty("secondary_genres")]
        public SecondaryGenres SecondaryGenres { get; set; }

        [JsonProperty("album_pline")]
        public string AlbumPline { get; set; }

        [JsonProperty("album_copyright")]
        public string AlbumCopyright { get; set; }

        [JsonProperty("album_label")]
        public string AlbumLabel { get; set; }

        [JsonProperty("updated_time")]
        public string UpdatedTime { get; set; }

        [JsonProperty("album_coverart_100x100")]
        public string AlbumCoverart100X100 { get; set; }
    }
}
