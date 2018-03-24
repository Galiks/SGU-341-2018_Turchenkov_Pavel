using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_2_a
{
    class Employee : User
    {

        private string position;
        private DateTime startWorking;

        public Employee(DateTime start_working, string _position, 
            string first_name, string last_name, string sur_name, DateTime dob) : 
            base(first_name, last_name, sur_name, dob)
        {
            StartWorking = start_working;
            Position = _position;
        }

        private DateTime StartWorking
        {
            get { return startWorking; }
            set
            {
                MyExceptions.IsNotNowDate(value);
                startWorking = value;
            }
        }
        private string Position
        {
            get { return position; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    position = value;
                }
            }
        }

        public override string Information()
        {
            var basic = base.Information();
            int workExperience = GetDate(StartWorking);
            return $"{basic}Стаж работы: {workExperience}{Environment.NewLine}Должность: {this.Position}";

        }
    }
}
