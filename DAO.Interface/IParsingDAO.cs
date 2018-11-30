using System.Collections.Generic;
using Entity;

namespace DAO
{
    public interface IParsingDAO
    {
        int AddData(AbstractSite letyShops, int id);
        int AddShop(Shop shop);
        IEnumerable<LetyShops> GetDiscounts();
    }
}