using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ADO.NET_Task_2_a
{
    public class ReadEmployeesFromFile
    {
        private const int number_of_date = 6;

        private List<string> info = new List<string>();

        public void ReadEmpolyeeFile(string name)
        {
            using (StreamReader file = new StreamReader(name + ".txt"))
            {
                while (file.EndOfStream)
                {
                    string line = file.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        info.Add(line);
                    }
                    else
                    {
                        throw new Exception("Invalid type of line");
                    }
                }
            }
            CheckException(info);
        }

        public void OutputEmployeeFile()
        {
            Employee employee = new Employee(DateTime.Parse(info[4]), info[5], info[0], info[1], info[2], DateTime.Parse(info[3]));
            Console.WriteLine(employee.Information());
        }

        private void CheckException(List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 5)
                {
                    MyExceptions.IsLetterOnly(lines[i]);
                }
                else
                {
                    MyExceptions.IsNotNowDate(lines[i]);
                }
            }
        }

    }
}
