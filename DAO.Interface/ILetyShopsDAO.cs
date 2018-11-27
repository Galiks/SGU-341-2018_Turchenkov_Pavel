using System.Collections.Generic;
using Entity;

namespace DAO
{
    public interface ILetyShopsDAO
    {
        int AddData(LetyShops letyShops, int id);
        int AddShop(Shop shop);
        IEnumerable<LetyShops> GetDiscounts();
    }
}