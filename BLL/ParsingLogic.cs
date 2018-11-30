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
        private readonly string patternDiscount = @"\d+[.]?\d*";
        private readonly string patternLabel = @"[$%€]|руб|cent";
        private readonly IParsingDAO _parsingDAO;
        private readonly Regex regexDiscount;
        private readonly Regex regexLabel;

        public ParsingLogic(IParsingDAO parsingDAO)
        {
            _parsingDAO = parsingDAO;

            regexDiscount = new Regex(patternDiscount);
            regexLabel = new Regex(patternLabel);
        }

        public bool AddShop(string shopName, string shopDiscount, string shopUrl, string shopImage, string dateAdd, string siteID, string shopLabel)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() { shopName, shopDiscount, shopImage, shopUrl, siteID, dateAdd, shopLabel}))
            {

                //а ведь мог в одну строчку пихнуть, чтобы люди на дипломе мучались
                Match matchDiscount = regexDiscount.Match(shopDiscount);
                Match matchLabel = regexLabel.Match(shopLabel);

                if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() {matchDiscount.Value, matchLabel.Value }))
                {
                    if (Double.TryParse(matchDiscount.Value, out double rightDiscount) && DateTime.TryParse(dateAdd, out DateTime rightDateAdd) && Int32.TryParse(siteID, out int rightSiteID))
                    {
                        _parsingDAO.AddShop(new Shop(shopName, rightDiscount, shopUrl, shopImage, rightDateAdd, rightSiteID, matchLabel.Value));

                        return true;
                    } 
                }
            }

            return false;
        }

        public bool AddSite(string siteName)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() { siteName}))
            {
                if (GetSiteByName(siteName).ToList().Count == 0)
                {
                    _parsingDAO.AddSite(new Site(siteName));

                    return true;
                }
            }

            return false;
        }

        public IEnumerable<AbstractShop> GetShopByDiscount(string shopDiscount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AbstractShop> GetShopByName(string shopName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AbstractShop> GetShops()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AbstractShop> GetShopsBySite(string siteID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Site> GetSiteByID(string siteID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Site> GetSiteByName(string siteName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Site> GetSites()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSite(string siteID, string siteName)
        {
            throw new NotImplementedException();
        }

        private bool CheckStringOnNullOrEmptyOrWhiteSpace(List<string> list)
        {
            foreach (var item in list)
            {
                if (String.IsNullOrEmpty(item) || String.IsNullOrWhiteSpace(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
