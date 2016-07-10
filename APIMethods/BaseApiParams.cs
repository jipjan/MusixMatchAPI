using System;
using System.Globalization;

namespace MusixMatch_API.APIMethods
{
    public class BaseApiParams
    {
        internal FilterCollection Filter;

        public enum SubtitleFormatOptions { Lrc, Dfxp, Stledu }
        public enum Sort { Ascending, Descending }

        public static string Format { get; } = "json";

        public void AddFilter(string param, string item)
        {
            if (item != "") Filter.Add(new Tuple<string, string>(param, item));
        }

        public void AddFilter(string param, int? item)
        {
            if (item.HasValue)
                Filter.Add(new Tuple<string, string>(param, item.ToString()));
        }

        public void AddFilter(string param, bool? item)
        {
            if (item.HasValue)
                Filter.Add(item.Value ? new Tuple<string, string>(param, "1") : new Tuple<string, string>(param, "0"));
        }

        public void AddFilter(string param, Sort? item)
        {
            if (item.HasValue)
                Filter.Add(item.Value == Sort.Ascending
                    ? new Tuple<string, string>(param, "asc")
                    : new Tuple<string, string>(param, "desc"));
        }

        public void AddFilter(string param, float? item)
        {
            if (item.HasValue)
                Filter.Add(new Tuple<string, string>(param, item.Value.ToString(CultureInfo.InvariantCulture)));
        }

        public void AddFilter(string param, SubtitleFormatOptions item)
        {
            switch (item)
            {
                case SubtitleFormatOptions.Lrc:
                    Filter.Add(new Tuple<string, string>(param, "lrc"));
                    break;
                case SubtitleFormatOptions.Dfxp:
                    Filter.Add(new Tuple<string, string>(param, "dfxp"));
                    break;
                case SubtitleFormatOptions.Stledu:
                    Filter.Add(new Tuple<string, string>(param, "stledu"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(item), item, null);
            }
        }
    }
}