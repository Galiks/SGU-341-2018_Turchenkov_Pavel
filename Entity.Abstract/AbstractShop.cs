using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class AbstractShop
    {
        public int IdShop { get; set; }
        public string Name { get; set; }
        public double Discount { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public DateTime Date_add { get; set; }
        public int IdSite { get; set; }
        public string Label { get; set; }

        protected AbstractShop(int idShop, string name, double discount, string url, string image, DateTime date_add, int idSite, string label)
        {
            IdShop = idShop;
            Name = name;
            Discount = discount;
            Url = url;
            Image = image;
            Date_add = date_add;
            IdSite = idSite;
            Label = label;
        }

        protected AbstractShop(string name, double discount, string url, string image, DateTime date_add, int idSite, string label)
        {
            Name = name;
            Discount = discount;
            Url = url;
            Image = image;
            Date_add = date_add;
            IdSite = idSite;
            Label = label;
        }

        protected AbstractShop()
        {
        }

    }
}
