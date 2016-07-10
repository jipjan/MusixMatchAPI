namespace MusixMatch_API.APIMethods.Chart
{
    public class ArtistsGet : BaseApiParams, IQueryable
    {
        public string CountryCode;
        public int? Page;
        public int? PageSize;

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("country", CountryCode);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);

            return Url + Filter;
        }

        public string Url { get; } = "chart.artists.get?";
    }
}
