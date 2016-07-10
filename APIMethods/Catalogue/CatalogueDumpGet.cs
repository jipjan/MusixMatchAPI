namespace MusixMatch_API.APIMethods.Catalogue
{
    class CatalogueDumpGet : BaseApiParams, IQueryable
    {
        public string ToUrlParams()
        {
            return "";
        }

        public string Url { get; } = "catalogue.dump.get";
    }
}
