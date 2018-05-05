namespace MusixMatch_API
{
    public interface IQueryable
    {
        string Url { get; }
        string ToUrlParams();
    }
}