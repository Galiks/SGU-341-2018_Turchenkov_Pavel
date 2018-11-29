using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinallyTaskForASP.Models
{
    public class LetyShopsModel : LetyShops
    {
        public override string Name { get => base.Name; set => base.Name = value; }
        public override string Discount { get => base.Discount; set => base.Discount = value; }
        public override string Url { get => base.Url; set => base.Url = value; }
        public override string Image { get => base.Image; set => base.Image = value; }
        public override string Date_add { get => base.Date_add; set => base.Date_add = value; }

        public LetyShopsModel(string name, string discount, string url, string image, string date_add)
        {
            Name = name;
            Discount = discount;
            Url = url;
            Image = image;
            Date_add = date_add;
        }
    }
}