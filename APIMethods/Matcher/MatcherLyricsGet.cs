namespace MusixMatch_API.APIMethods.Matcher
{
    public class MatcherLyricsGet : BaseApiParams, IQueryable
    {
        public string SongTitle;
        public string SongArtist;


        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("q_track", SongTitle);
            AddFilter("q_artist", SongArtist);

            return Url + Filter;
        }

        public string Url { get; } = "matcher.lyrics.get?";
    }
}
