namespace MusixMatch_API
{
    public interface IQueryable
    {
        string ToUrlParams();
        string Url { get; }
    }
}