using System.Collections.Generic;
using Entity;

namespace DAO
{
    public interface IParsingDAO
    {
        int AddShop(Shop shop);
        int AddSite(Site site);
        IEnumerable<Shop> GetShops();
        IEnumerable<Site> GetSites();
        IEnumerable<Shop> GetShopsBySite(int siteID);
        Site GetSiteByID(int siteID);
        Site GetSiteByName(string siteName);
        IEnumerable<Shop> GetShopByDiscount(double shopDiscount);
        IEnumerable<Shop> GetShopByName(string shopName);
        int UpdateSite(int siteID, string siteName);
        int DeleteDataFromShop();
    }
}