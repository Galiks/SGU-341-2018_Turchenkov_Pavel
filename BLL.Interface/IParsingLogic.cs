using Entity;
using System;
using System.Text.RegularExpressions;

namespace BLL
{
    public interface IParsingLogic
    {
        Regex RegexDiscount { get; set; }

        bool AddData(AbstractSite site);
        bool AddShop(string name);
    }
}