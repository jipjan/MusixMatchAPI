namespace MusixMatch_API.APIMethods.Track
{
    public class TrackLyricsFeedbackPost : BaseApiParams, IQueryable
    {
        public TrackLyricsFeedbackPost(int lyricsId, int trackId, string feedback)
        {
            LyricsId = lyricsId;
            TrackId = trackId;
            Feedback = feedback;
        }

        public int LyricsId { get; }
        public int TrackId { get; }
        public string Feedback { get; }


        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("lyrics_id", LyricsId);
            AddFilter("track_id", TrackId);
            AddFilter("feedback", Feedback);

            return Url + Filter;
        }

        public string Url { get; } = "track.lyrics.feedback.post?";
    }
}
