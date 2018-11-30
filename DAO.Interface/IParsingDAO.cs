﻿using System.Collections.Generic;
using Entity;

namespace DAO
{
    public interface IParsingDAO
    {
        int AddShop(AbstractShop shop);
        int AddSite(Site site);
        IEnumerable<AbstractShop> GetShops();
        IEnumerable<Site> GetSites();
        IEnumerable<AbstractShop> GetShopsBySite(int siteID);
        IEnumerable<Site> GetSiteByID(int siteID);
        IEnumerable<Site> GetSiteByName(string siteName);
        IEnumerable<AbstractShop> GetShopByDiscount(double shopDiscount);
        IEnumerable<AbstractShop> GetShopByName(string shopName);
        int UpdateSite(int siteID, string siteName);
    }
}