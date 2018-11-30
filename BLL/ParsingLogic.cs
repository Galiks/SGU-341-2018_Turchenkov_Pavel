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

        public bool AddShop(string shopName, string shopDiscount, string shopUrl, string shopImage, string dateAdd, string siteID)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() { shopName, shopDiscount, shopImage, shopUrl, siteID, dateAdd }))
            {

                //а ведь мог в одну строчку пихнуть, чтобы люди на дипломе мучались
                Match matchDiscount = regexDiscount.Match(shopDiscount);
                Match matchLabel = regexLabel.Match(shopDiscount);

                if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() { matchDiscount.Value, matchLabel.Value }))
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
            if (CheckStringOnNullOrEmptyOrWhiteSpace(siteName))
            {
                if (GetSiteByName(siteName) == null)
                {
                    _parsingDAO.AddSite(new Site(siteName));

                    return true;
                }
            }

            return false;
        }

        public IEnumerable<AbstractShop> GetShopByDiscount(string shopDiscount)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(shopDiscount))
            {
                if (Double.TryParse(shopDiscount, out double rightDiscount))
                {
                    return _parsingDAO.GetShopByDiscount(rightDiscount).ToList();
                }
            }

            return null;
        }

        public IEnumerable<AbstractShop> GetShopByName(string shopName)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(shopName))
            {
                return _parsingDAO.GetShopByName(shopName).ToList();
            }

            return null;
        }

        public IEnumerable<AbstractShop> GetShops()
        {
            return _parsingDAO.GetShops();
        }

        public IEnumerable<AbstractShop> GetShopsBySite(string siteID)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(siteID))
            {
                if (Int32.TryParse(siteID, out int rightSiteID))
                {
                    return _parsingDAO.GetShopByDiscount(rightSiteID).ToList();
                }
            }

            return null;
        }

        public Site GetSiteByID(string siteID)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(siteID))
            {
                if (Int32.TryParse(siteID, out int rightSiteID))
                {
                    return _parsingDAO.GetSiteByID(rightSiteID);
                }
            }

            return null;
        }

        public Site GetSiteByName(string siteName)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(siteName))
            {
                return _parsingDAO.GetSiteByName(siteName);
            }

            return null;
        }

        public IEnumerable<Site> GetSites()
        {
            return _parsingDAO.GetSites().ToList();
        }

        public bool UpdateSite(string siteID, string siteName)
        {
            if (CheckStringOnNullOrEmptyOrWhiteSpace(new List<string>() { siteID, siteName}))
            {
                if (Int32.TryParse(siteID, out int rightSiteID))
                {
                    if (_parsingDAO.GetSiteByID(rightSiteID) != null)
                    {
                        _parsingDAO.UpdateSite(rightSiteID, siteName);

                        return true; 
                    }
                }
            }

            return false;
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

        private bool CheckStringOnNullOrEmptyOrWhiteSpace(string line)
        {
            if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            return true;
        }
    }
}
