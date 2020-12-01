using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public int Id
        {
            get; set;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public bool AccessToPluralsight { get; set; }
        public Developer() { }
        public Developer(int id, string name, string email, int salary, bool accessToPluralsight)
        {
            Id = id;
            Name = name;
            AccessToPluralsight = accessToPluralsight;
            Email = email;
            Salary = salary;
        }

    }
}
