using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class TrackList
    {
        public Track Track { get; set; }
    }

    public class Track
    {
        [JsonProperty("track_id")]
        public int TrackId { get; set; }

        [JsonProperty("track_mbid")]
        public string TrackMbid { get; set; }

        [JsonProperty("track_spotify_id")]
        public string TrackSpotifyId { get; set; }

        [JsonProperty("track_soundcloud_id")]
        public int TrackSoundcloudId { get; set; }

        [JsonProperty("track_name")]
        public string TrackName { get; set; }

        [JsonProperty("track_rating")]
        public int TrackRating { get; set; }

        [JsonProperty("track_length")]
        public int TrackLength { get; set; }

        [JsonProperty("commontrack_id")]
        public int CommontrackId { get; set; }

        [JsonProperty("instrumental")]
        public int Instrumental { get; set; }

        [JsonProperty("@explicit")]
        public int Explicit { get; set; }

        [JsonProperty("has_lyrics")]
        public int HasLyrics { get; set; }

        [JsonProperty("has_subtitles")]
        public int HasSubtitles { get; set; }

        [JsonProperty("num_favourite")]
        public int NumFavourite { get; set; }

        [JsonProperty("lyrics_id")]
        public int LyricsId { get; set; }

        [JsonProperty("subtitle_id")]
        public int SubtitleId { get; set; }

        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("album_name")]
        public string AlbumName { get; set; }

        [JsonProperty("artist_id")]
        public int ArtistId { get; set; }

        [JsonProperty("artist_mbid")]
        public string ArtistMbid { get; set; }

        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }

        [JsonProperty("album_coverart_100x100")]
        public string AlbumCoverart100X100 { get; set; }

        [JsonProperty("album_coverart_350x350")]
        public string AlbumCoverart350X350 { get; set; }

        [JsonProperty("album_coverart_500x500")]
        public string AlbumCoverart500X500 { get; set; }

        [JsonProperty("album_coverart_800x800")]
        public string AlbumCoverart800X800 { get; set; }

        [JsonProperty("track_share_url")]
        public string TrackShareUrl { get; set; }

        [JsonProperty("track_edit_url")]
        public string TrackEditUrl { get; set; }

        [JsonProperty("updated_time")]
        public string UpdatedTime { get; set; }

        [JsonProperty("primary_genres")]
        public PrimaryGenres PrimaryGenres { get; set; }

        [JsonProperty("secondary_genres")]
        public SecondaryGenres SecondaryGenres { get; set; }
    }
}
