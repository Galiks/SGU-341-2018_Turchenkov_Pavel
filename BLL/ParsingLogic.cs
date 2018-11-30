using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class ParsingLogic : IParsingLogic
    {
        private const string patternDiscount = @"\d+[.]?\d*";

        private readonly IParsingDAO _letyShopsDAO;

        private Regex regexDiscount;

        public ParsingLogic(IParsingDAO letyShopsDAO)
        {
            _letyShopsDAO = letyShopsDAO;

            regexDiscount = new Regex(patternDiscount);
        }

        public Regex RegexDiscount { get => regexDiscount; set => regexDiscount = value; }

        public bool AddData(AbstractSite site)
        {
            if (!String.IsNullOrEmpty(site.Name) || !String.IsNullOrEmpty(site.Discount))
            {
                _letyShopsDAO.AddData(site, 1);

                return true;
            }
            return false;
        }

        public bool AddShop(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                _letyShopsDAO.AddShop(new Shop(name));

                return true;
            }

            return false;
        }
    }
}
