using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using HtmlAgilityPack;

namespace Parsing
{
    public class SiteParsing: ISiteParsing
    {

        private List<ISiteParsing> sites;

        public List<ISiteParsing> Sites { get => sites; set => sites = value; }

        public SiteParsing(List<ISiteParsing> sites)
        {
            this.Sites = sites;
        }

        public void Parsing()
        {
            foreach (var item in Sites)
            {
                item.Parsing();
            }
        }
    }
}
