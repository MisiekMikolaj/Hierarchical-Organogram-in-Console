using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;




namespace Acturis_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>();

            var path = "C:/Users/Legion/Desktop/organogram/TestCSharp/companies_data.csv";
            using (var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while(!String.IsNullOrEmpty(line))
                {
                    employee.Add(new Employee(line));
                    line = reader.ReadLine();
                }
            }
            
            foreach (var i in employee )
            {
                i.SplitData();
            }
            employee = employee.OrderBy(o => o.RowId).ToList();
            employee = employee.OrderBy(o => o.ParentRecord).ToList();
            
            List<Employee> nowa = new List<Employee>();

            Employee.SequenceEmps(nowa, employee);
            Employee.Organogram(nowa);

            Console.ReadLine();
        }
    }
}