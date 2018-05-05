namespace MusixMatch_API.APIMethods.Album
{
    public class AlbumGet : BaseApiParams, IQueryable
    {
        public int? MusixMatchAlbumId;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("album_id", MusixMatchAlbumId);

            return Url + Filter;
        }

        public string Url { get; } = "album.get?";
    }
}