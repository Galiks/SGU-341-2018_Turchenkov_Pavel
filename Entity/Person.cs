using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Person(int personID, string name, string password)
        {
            PersonID = personID;
            Name = name;
            Password = password;
        }

        public Person(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public Person()
        {
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
