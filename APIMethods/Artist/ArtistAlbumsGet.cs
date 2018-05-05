namespace MusixMatch_API.APIMethods.Artist
{
    public class ArtistAlbumsGet : BaseApiParams, IQueryable
    {
        public bool? GroupByAlbumName;
        public int? MusicBrainzArtistId;
        public int? MusixMatchArtistId;
        public int? Page;
        public int? PageSize;
        public Sort? SortReleaseDate;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("artist_id", MusixMatchArtistId);
            AddFilter("artist_mbid", MusicBrainzArtistId);
            AddFilter("g_album_name", GroupByAlbumName);
            AddFilter("s_release_date", SortReleaseDate);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);

            return Url + Filter;
        }

        public string Url { get; } = "artist.albums.get?";
    }
}