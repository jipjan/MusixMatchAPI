namespace MusixMatch_API.APIMethods.Matcher
{
    public class MatcherSubtitleGet : BaseApiParams, IQueryable
    {
        public string SongTitle;
        public string SongArtist;
        public int? SubtitleLength;
        public int? SubtitleLengthMaxDeviation;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("q_track", SongTitle);
            AddFilter("q_artist", SongArtist);
            AddFilter("f_subtitle_length", SubtitleLength);
            AddFilter("f_subtitle_length_max_deviation", SubtitleLengthMaxDeviation);

            return Url + Filter;
        }

        public string Url { get; } = "matcher.subtitle.get?";
    }
}
