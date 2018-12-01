using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinallyTaskForASP.Models
{
    public class PersonModel : Person
    {
        public PersonModel()
        {
        }

        public PersonModel(string name) : base(name)
        {
        }

        public PersonModel(string name, string password) : base(name, password)
        {
        }

        public PersonModel(int personID, string name, string password) : base(personID, name, password)
        {
        }
    }
}