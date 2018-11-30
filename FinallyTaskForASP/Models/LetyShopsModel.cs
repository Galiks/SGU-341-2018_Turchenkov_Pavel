using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinallyTaskForASP.Models
{
    public class LetyShopsModel : Shop
    {
        public LetyShopsModel()
        {
        }

        public LetyShopsModel(string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(name, discount, url, image, date_add, idSite, label)
        {
        }

        public LetyShopsModel(int idShop, string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(idShop, name, discount, url, image, date_add, idSite, label)
        {
        }
    }
}