using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LetyShops: AbstractSite
    {
        public override string Name { get; set; }
        public override string Discount { get; set; }
        public override string Url { get; set; }
        public override string Image { get; set; }
        public override string Date_add { get; set; }
        

        public LetyShops(string name, string discount, string url, string image, string date_add)
        {
            Name = name;
            Discount = discount;
            Url = url;
            Image = image;
            Date_add = date_add;
        }

        public LetyShops()
        {

        }
    }
}
