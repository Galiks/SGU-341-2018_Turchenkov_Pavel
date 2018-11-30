using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Shop
    {
        public int IdShop { get; set; }
        public string Name { get; set; }

        public Shop(string name)
        {
            Name = name;
        }

        public Shop(int idShop, string name)
        {
            IdShop = idShop;
            Name = name;
        }
    }
}
