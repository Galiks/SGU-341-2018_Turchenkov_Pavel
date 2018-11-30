using Entity;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL
{
    public interface IParsingLogic
    {
        bool AddShop(string shopName, string shopDiscount, string shopUrl, string shopImage, string dateAdd, string siteID);
        bool AddSite(string siteName);
        IEnumerable<AbstractShop> GetShops();
        IEnumerable<Site> GetSites();
        IEnumerable<AbstractShop> GetShopsBySite(string siteID);
        Site GetSiteByID(string siteID);
        Site GetSiteByName(string siteName);
        IEnumerable<AbstractShop> GetShopByDiscount(string shopDiscount);
        IEnumerable<AbstractShop> GetShopByName(string shopName);
        bool UpdateSite(string siteID, string siteName);
    }
}