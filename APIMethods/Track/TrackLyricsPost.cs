namespace MusixMatch_API.APIMethods.Track
{
    public class TrackLyricsPost : BaseApiParams, IQueryable
    {
        public TrackLyricsPost(int musixMatchId, string lyrics)
        {
            MusixMatchId = musixMatchId;
            Lyrics = lyrics;
        }

        public int MusixMatchId { get; }
        public string Lyrics { get; }

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("track_id", MusixMatchId);
            AddFilter("lyrics_body", Lyrics);

            return Url + Filter;
        }

        public string Url { get; } = "track.lyrics.post?";
    }
}
