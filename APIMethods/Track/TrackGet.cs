namespace MusixMatch_API.APIMethods.Track
{
    public class TrackGet : BaseApiParams, IQueryable
    {
        //track_id
        public int MusixMatchId;
        //track_mbid
        public int MusicBrainzId;

        //format
        public string Url { get; } = "track.get?";

        public string ToUrlParams()
        {
            Filter = new FilterCollection();
            AddFilter("track_id", MusixMatchId);
            AddFilter("track_mbid", MusicBrainzId);
            return Url + Filter;
        }
    }
}