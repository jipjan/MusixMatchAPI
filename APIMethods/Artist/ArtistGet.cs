namespace MusixMatch_API.APIMethods.Artist
{
    public class ArtistGet : BaseApiParams, IQueryable
    {
        public int? MusicBrainzArtistId;
        public int? MusixMatchArtistId;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("artist_id", MusixMatchArtistId);
            AddFilter("artist_mbid", MusicBrainzArtistId);

            return Url + Filter;
        }

        public string Url { get; } = "artist.get?";
    }
}