using System;
using System.Collections.Generic;


namespace Acturis_1
{
    public class Employee
    {
        public string line;
        private int rowId;
        private int parentRecord;
        private string name;
        private string surname;
        private string company;
        private string place;
        private string position;
        private string data1;
        private string data2;
        private string data3;
        private string word;
        private int counter = 0;
        public string indentation = "";
        public string arrow = "";

        public Employee(string line)
        {
            this.line = line;
        }
        public string Position
        {
            get
            {
                return this.position;
            }
        }
        public string Data3
        {
            get
            {
                return this.data3;
            }
        }
        public string Data2
        {
            get
            {
                return this.data2;
            }
        }
        public string Data1
        {
            get
            {
                return this.data1;
            }
        }
        public string Company
        {
            get
            {
                return this.company;
            }
        }
        public string Place
        {
            get
            {
                return this.place;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string Surname
        {
            get
            {
                return this.surname;
            }
        }
        public int RowId
        {
            get
            {
                return this.rowId;
            }
        }
        public int ParentRecord
        {
            get
            {
                return this.parentRecord;
            }
        }
        public void SplitData()
        {
            foreach (var i in line)
            {
                if (i != ',')
                {
                    word += i;
                    line = line.Substring(1);
                }
                if (i == ',')
                {
                    line = line.Substring(1);
                    counter += 1;
                    switch(counter)
                    {
                        case 1:
                            rowId = int.Parse(word);
                            word = "";
                            break;
                        case 2:
                            parentRecord = int.Parse(word);
                            word = "";
                            break;
                        case 3:
                            name = (word);
                            word = "";
                            break;
                        case 4:
                            surname = (word);
                            word = ""; ;
                            break;
                        case 5:
                            company = (word);
                            word = "";
                            break;
                        case 6:
                            place = (word);
                            word = "";
                            break;
                        case 7:
                            position = (word);
                            word = "";
                            break;
                        case 8:
                            data1 = (word);
                            word = ""; ;
                            break;
                        case 9:
                            data2 = (word);
                            data3 = (line);
                            word = "";
                            break;
                    }
                }
            }
        }
        public static void SequenceEmps(List<Employee> nowa, List<Employee> employee)
        {
            int indeks = 0;
            bool czy = true;
            nowa.Add(employee[0]);
            employee.RemoveAt(0);

            while (employee.Count > 1)
            {
                while (czy)
                {
                    for (int j = 0; j < employee.Count; j++)
                    {
                        if (nowa[indeks].RowId == employee[j].ParentRecord)
                        {
                            nowa.Add(employee[j]);
                            employee.RemoveAt(j);
                            indeks += 1;
                            break;
                        }

                        czy = false;
                    }
                }
                for (int j = 0; j < employee.Count; j++)
                {
                    if (nowa[nowa.Count - 1].RowId == employee[j].ParentRecord)
                    {
                        nowa.Add(employee[j]);
                        employee.RemoveAt(j);
                        indeks = nowa.Count - 1;
                    }
                }
                if (czy == false)
                {
                    if (indeks == 0)
                    {
                        nowa.Add(employee[0]);
                        employee.RemoveAt(0);
                        indeks = nowa.Count - 1;
                    }
                    if (indeks > 0)
                    {
                        indeks -= 1;
                    }
                    czy = true;
                }
                if (employee.Count == 1)
                {
                    nowa.Add(employee[0]);
                }
            }
        }
        public string WriteData()
        {
            return ($"{indentation} {arrow} {rowId} {parentRecord} {name} {surname} {company} {place} {position} {data1} {data2} {data3} ");
        }

        public static void Organogram(List<Employee> nowa)
        {
            foreach (var i in nowa)
            {   
                for(int j = 0; j<nowa.Count; j++)
                {
                    if(i.ParentRecord == nowa[j].RowId)
                    {
                        i.indentation = nowa[j].indentation + "    ";
                    }
                }
                if (i.ParentRecord != 0)
                {
                    i.arrow = "->";
                }
                Console.WriteLine(i.WriteData());
            }
        }

    }
}
