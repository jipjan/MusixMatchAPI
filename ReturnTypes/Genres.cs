using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusixMatch_API.ReturnTypes
{
    public class MusicGenreList
    {
        [JsonProperty("music_genre")]
        public MusicGenre MusicGenre { get; set; }
    }

    public class PrimaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<MusicGenreList> MusicGenreList { get; set; }
    }

    public class MusicGenre
    {
        [JsonProperty("music_genre_id")]
        public int MusicGenreId { get; set; }

        [JsonProperty("music_genre_parent_id")]
        public int MusicGenreParentId { get; set; }

        [JsonProperty("music_genre_name")]
        public string MusicGenreName { get; set; }

        [JsonProperty("music_genre_name_extended")]
        public string MusicGenreNameExtended { get; set; }
    }

    public class SecondaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<MusicGenreList> MusicGenreList { get; set; }
    }
}
