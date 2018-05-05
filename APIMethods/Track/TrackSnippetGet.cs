namespace MusixMatch_API.APIMethods.Track
{
    public class TrackSnippetGet : BaseApiParams, IQueryable
    {
        public int? MusixMatchId;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("track_id", MusixMatchId);

            return Url + Filter;
        }

        public string Url { get; } = "track.snippet.get?";
    }
}