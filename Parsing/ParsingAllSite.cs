using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parsing
{
    public class ParsingAllSite : ISiteParsing
    {
        LetyShopsParsing letyShopsParsing;

        public int? MaxPage { get; set; }
        public HtmlWeb WebGet { get; set; }
        public LetyShopsParsing LetyShopsParsing { get => letyShopsParsing; set => letyShopsParsing = value; }

        public ParsingAllSite(LetyShopsParsing letyShopsParsing)
        {
            this.letyShopsParsing = letyShopsParsing;


        }

        public void Parsing()
        {
            letyShopsParsing.Parsing();
        }

        public IEnumerable ShowData()
        {
            return letyShopsParsing.ShowData();
        }
    }
}
