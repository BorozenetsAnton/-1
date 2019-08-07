using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace WindowsFormsApp2
{
    class Student: IComparable
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Student ()
        {
            Name = "unknow";
            Number = 0;
        }

        public Student (string name,int num)
        {
            Name = name;
            Number = num;
        }
        public  string printinfo()
        {
            string s = this.Number.ToString() +" "+ this.Name.ToString() + "\n";
            return s;
        }

        public int CompareTo(object obj)
        {
            return Number.CompareTo(obj);
        }
    }
}
