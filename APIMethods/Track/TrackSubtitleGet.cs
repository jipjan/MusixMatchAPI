namespace MusixMatch_API.APIMethods.Track
{
    public class TrackSubtitleGet : BaseApiParams, IQueryable
    {
        //track_id
        public int? MusixMatchId;
        //track_mbid
        public int? MusicBrainzId;

        public SubtitleFormatOptions SubtitleFormat = SubtitleFormatOptions.Lrc;

        public int? SubtitleLength;
        public int? SubtitleLengthMaxDeviation;
        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("track_id", MusixMatchId);
            AddFilter("track_mbid", MusicBrainzId);
            AddFilter("subtitle_format", SubtitleFormat);
            AddFilter("f_subtitle_length", SubtitleLength);
            AddFilter("f_subtitle_length_max_deviation", SubtitleLengthMaxDeviation);

            return Url + Filter;
        }

        public string Url { get; } = "track.subtitle.get?";
    }
}
