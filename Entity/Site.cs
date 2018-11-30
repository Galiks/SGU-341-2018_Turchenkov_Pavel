using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Site
    {
        public int IdSite { get; set; }
        public string Name { get; set; }

        public Site(string name)
        {
            Name = name;
        }

        public Site(int idSite, string name)
        {
            IdSite = idSite;
            Name = name;
        }

        public Site()
        {
        }
    }
}
