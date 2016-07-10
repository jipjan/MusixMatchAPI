namespace MusixMatch_API.APIMethods.Tracking
{
    public class TrackingUrlGet : BaseApiParams, IQueryable
    {
        public string Domain;

        public TrackingUrlGet(string domain)
        {
            Domain = domain;
        }
        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("domain", Domain);

            return Url + Filter;
        }

        public string Url { get; } = "tracking.url.get?";
    }
}
