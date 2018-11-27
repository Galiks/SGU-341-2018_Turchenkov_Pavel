using HtmlAgilityPack;

namespace Parsing
{
    public interface ISiteParsing
    {
        int? MaxPage { get; set; }
        HtmlWeb WebGet { get; set; }

        void MainMethod();
    }
}