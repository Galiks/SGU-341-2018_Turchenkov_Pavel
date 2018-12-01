using System.Collections.Generic;
using BLL;
using Ninject;
using NinjectCommon;

namespace Parsing
{
    public class AllSitesParsing
    {
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();
        private List<ISiteParsing> sites;

        public List<ISiteParsing> Sites { get => sites; set => sites = value; }

        public AllSitesParsing()
        {
            Sites = new List<ISiteParsing>()
            {
                new LetyShopsParsing(parsingLogic)
            };
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
