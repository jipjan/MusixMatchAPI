namespace MusixMatch_API.APIMethods.Album
{
    public class AlbumTracksGet : BaseApiParams, IQueryable
    {
        public bool? HasLyrics;
        public int? MusicBrainzAlbumId;
        public int? MusixMatchAlbumId;
        public int? Page;
        public int? PageSize;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("album_id", MusixMatchAlbumId);
            AddFilter("album_mbid", MusicBrainzAlbumId);
            AddFilter("f_has_lyrics", HasLyrics);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);

            return Url + Filter;
        }

        public string Url { get; } = "album.tracks.get?";
    }
}