using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LetyShops
    {
        public string Name { get; set; }
        public double Discount { get; set; }
        public DateTime Date_add { get; set; }

        public LetyShops(string name, double discount, DateTime date_add)
        {
            Name = name;
            Discount = discount;
            Date_add = date_add;
        }

        public LetyShops()
        {
        }
    }
}
