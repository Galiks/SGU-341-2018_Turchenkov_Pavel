using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADO.NET_Task_2_a
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadEmployeesFromFile File = new ReadEmployeesFromFile();

            File.ReadEmpolyeeFile("Person");
            File.OutputEmployeeFile();

            //Employee emp = new Employee(DateTime.Parse("2017-02-02"), "position", "firstname", "lastname", "surname", DateTime.Parse("2017-02-02"));

            //emp.Information();

            Console.Read();
        }
    }
}
