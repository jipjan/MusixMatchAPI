using System;
using System.Collections.Generic;
using MusixMatch_API.APIMethods;

namespace MusixMatch_API
{
    public class FilterCollection : List<Tuple<string, string>>
    {
        public override string ToString()
        {
            var toReturn = "";
            foreach (var item in this)
                toReturn += item.Item1 + "=" + item.Item2 + "&";
            return toReturn + "format=" + BaseApiParams.Format;
        }
    }
}
