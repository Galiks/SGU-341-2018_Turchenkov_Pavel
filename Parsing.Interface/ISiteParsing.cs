using HtmlAgilityPack;
using System.Collections;

namespace Parsing
{
    public interface ISiteParsing
    {
        int? MaxPage { get; set; }
        HtmlWeb WebGet { get; set; }

        void Parsing();
        IEnumerable ShowData();
    }
}