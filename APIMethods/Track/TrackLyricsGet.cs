namespace MusixMatch_API.APIMethods.Track
{
    public class TrackLyricsGet : BaseApiParams, IQueryable
    {
        //track_id
        public int? MusixMatchId;
        //track_mbid
        public int? MusicBrainzId;
        
        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("track_id", MusixMatchId);
            AddFilter("track_mbid", MusicBrainzId);

            return Url + Filter;
        }

        public string Url { get; } = "track.lyrics.get?";
    }
}
