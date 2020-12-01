using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        private int count = 1;
        public int Id
        {
            get
            {
                return count++;
            }
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public bool AccessToPluralsight { get; set; }
        public Developer() { }
        public Developer(string name, string email, int salary, bool accessToPluralsight)
        {
            Name = name;
            AccessToPluralsight = accessToPluralsight;
            Email = email;
            Salary = salary;
        }

    }
}
