using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class AbstractSite
    {
        abstract public string Name { get; set; }
        abstract public string Discount { get; set; }
        abstract public string Url { get; set; }
        abstract public string Image { get; set; }
        abstract public string Date_add { get; set; }

        protected AbstractSite(string name,string discount, string url, string image, string date_add)
        {
            Name = name;
            Discount = discount;
            Url = url;
            Image = image;
            Date_add = date_add;
        }

        protected AbstractSite()
        {
        }
    }
}
