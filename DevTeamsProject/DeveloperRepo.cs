using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create

        public void AddDeveloper(Developer developer)
        {
            _developerDirectory.Add(developer);
        }

        //Developer Read

        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateDeveloper(int Id, Developer update)
        {
            Developer old = GetDeveloperById(Id);

            if (old != null)
            {
                old.Name = update.Name;
                old.AccessToPluralsight = update.AccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool DeleteDeveloper(int Id)
        {
            Developer developer = GetDeveloperById(Id);
            if (developer == null)
            {
                return false;
            }
            return _developerDirectory.Remove(developer);
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperById(int Id)
        {
            foreach (Developer i in _developerDirectory)
            {
                if (i.Id == Id)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
