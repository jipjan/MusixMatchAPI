namespace MusixMatch_API.APIMethods.Artist
{
    public class ArtistRelatedGet : BaseApiParams, IQueryable
    {
        public int? MusixMatchArtistId;
        public int? MusicBrainzArtistId;
        public int? Page;
        public int? PageSize;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("artist_id", MusixMatchArtistId);
            AddFilter("artist_mbid", MusicBrainzArtistId);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);

            return Url + Filter;
        }

        public string Url { get; } = "artist.related.get?";
    }
}
