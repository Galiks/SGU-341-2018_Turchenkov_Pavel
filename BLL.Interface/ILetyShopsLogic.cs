using System;
using System.Text.RegularExpressions;

namespace BLL
{
    public interface ILetyShopsLogic
    {
        Regex RegexDiscount { get; set; }

        bool AddData(string name, string discount, DateTime timeAdd, int id);
        bool AddShop(string name);
    }
}