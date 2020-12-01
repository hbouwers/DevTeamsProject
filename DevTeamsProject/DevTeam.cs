using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public List<Developer> _developers = new List<Developer>();

        public string Name { get; set; }
        public DevTeam() { }
        public DevTeam(string name)
        {
            Name = name;
        }
    }
}

