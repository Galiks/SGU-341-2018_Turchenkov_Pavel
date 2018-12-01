using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinallyTaskForASP.Models
{
    public class ShopsModel : Shop
    {
        public ShopsModel()
        {
        }

        public ShopsModel(string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(name, discount, url, image, date_add, idSite, label)
        {
        }

        public ShopsModel(int idShop, string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(idShop, name, discount, url, image, date_add, idSite, label)
        {
        }
    }
}