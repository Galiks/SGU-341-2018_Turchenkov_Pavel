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
    public class LetyShopsLogic : ILetyShopsLogic
    {
        private const string patternDiscount = @"\d+[.]?\d*";

        private readonly ILetyShopsDAO _letyShopsDAO;

        private Regex regexDiscount;

        public LetyShopsLogic(ILetyShopsDAO letyShopsDAO)
        {
            _letyShopsDAO = letyShopsDAO;

            regexDiscount = new Regex(patternDiscount);
        }

        public Regex RegexDiscount { get => regexDiscount; set => regexDiscount = value; }

        public bool AddData(string name, string discount, DateTime timeAdd, int id)
        {
            if (!String.IsNullOrEmpty(name) | !String.IsNullOrEmpty(discount))
            {
                Match match = RegexDiscount.Match(discount);

                if (Double.TryParse(match.Value, out double rightDiscount))
                {
                    _letyShopsDAO.AddData(new LetyShops(name, rightDiscount, timeAdd), 1);

                    return true;
                }
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
