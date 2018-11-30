using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Shop : AbstractShop
    {
        public Shop()
        {
        }

        public Shop(string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(name, discount, url, image, date_add, idSite, label)
        {
        }

        public Shop(int idShop, string name, double discount, string url, string image, DateTime date_add, int idSite, string label) : base(idShop, name, discount, url, image, date_add, idSite, label)
        {
        }
    }
}
