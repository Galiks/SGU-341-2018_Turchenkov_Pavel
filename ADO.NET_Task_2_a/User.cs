using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_2_a
{
    public class User
    {
        private string firstname;
        private string lastname;
        private string surname;
        private DateTime dayOfBirthday;

        protected User(string firstName, string lastName, string surName, DateTime dob)
        {
            Firstname = firstName;
            Lastname = lastName;
            Surname = surName;
            DateOfBirthday = dob;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    MyExceptions.IsLetterOnly(value);
                    firstname = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    MyExceptions.IsLetterOnly(value);
                    lastname = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    MyExceptions.IsLetterOnly(value);
                    surname = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public DateTime DateOfBirthday
        {
            get { return dayOfBirthday; }
            set
            {
                MyExceptions.IsNotNowDate(value);
                dayOfBirthday = value;
            }
        }

        public int Age
        {
            get { return GetDate(DateOfBirthday); }
        }

        protected int GetDate(DateTime date)
        {
            if (DateTime.Today.Month > date.Month)
            {
                return (DateTime.Today.Year - date.Year);
            }
            else
            {
                return (DateTime.Today.Year - date.Year) - 1;
            }
        }

        public virtual string Information()
        {
            int Age = GetDate(dayOfBirthday);
            return $"Имя: {Firstname}{Environment.NewLine}Фамилия: {Lastname}{Environment.NewLine}Отчество: {Surname}{Environment.NewLine}Год рождения: {DateOfBirthday.Year} {DateOfBirthday.Month} {DateOfBirthday.Day}{Environment.NewLine}Полных лет: {Age}{Environment.NewLine}";
          
        }

    }
}
