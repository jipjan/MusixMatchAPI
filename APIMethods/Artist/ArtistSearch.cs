namespace MusixMatch_API.APIMethods.Artist
{
    public class ArtistSearch : BaseApiParams, IQueryable
    {
        public string ArtistName;
        public int? MusicBrainzArtistId;
        public int? MusixMatchArtistId;
        public int? Page;
        public int? PageSize;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("q_artist", ArtistName);
            AddFilter("artist_id", MusixMatchArtistId);
            AddFilter("artist_mbid", MusicBrainzArtistId);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);

            return Url + Filter;
        }

        public string Url { get; } = "artist.search?";
    }
}