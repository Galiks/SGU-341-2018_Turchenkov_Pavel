using Entity;
using System;
using System.Text.RegularExpressions;

namespace BLL
{
    public interface ILetyShopsLogic
    {
        Regex RegexDiscount { get; set; }

        bool AddData(LetyShops letyShops);
        bool AddShop(string name);
    }
}