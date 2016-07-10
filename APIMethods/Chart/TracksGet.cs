namespace MusixMatch_API.APIMethods.Chart
{
    public class TracksGet : BaseApiParams, IQueryable
    {
        public string CountryCode;
        public int? Page;
        public int? PageSize;
        public bool? HasLyrics;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("country", CountryCode);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);
            AddFilter("f_has_lyrics", HasLyrics);

            return Url + Filter;
        }

        public string Url { get; } = "chart.tracks.get?";
    }
}
