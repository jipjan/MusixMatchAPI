namespace MusixMatch_API.APIMethods.Matcher
{
    public class MatcherTrackGet : BaseApiParams, IQueryable
    {
        public string SongTitle;
        public string SongArtist;
        public string SongAlbum;
        public bool? HasLyrics;
        public bool? HasSubtitle;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("q_track", SongTitle);
            AddFilter("q_artist", SongArtist);
            AddFilter("q_album", SongAlbum);
            AddFilter("f_has_lyrics", HasLyrics);
            AddFilter("f_has_subtitle", HasSubtitle);

            return Url + Filter;
        }

        public string Url { get; } = "matcher.track.get?";
    }
}
