using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        // I have some confusion here - why are we creating a new instance of DeveloperRepo - can we access the methods with a using statment?
        // private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddDevTeam(DevTeam team)
        {
            _devTeams.Add(team);
        }

        public string AddDevToTeamById(Developer dev, string name)
        {
            if (dev == null)
            {
                return "Developer not found";
            }

            DevTeam team = GetDevTeamByName(name);

            if (team == null)
            {
                return "Team not found";
            }
            else
            {
                team._developers.Add(dev);
                return $"{dev.Name} was successfully added to {team.Name}";
            }

        }

        //DevTeam Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }


        //DevTeam Update
        public bool UpdateDevTeam(string name)
        {
            DevTeam old = GetDevTeamByName(name);

            if (name != null)
            {
                old.Name = name;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool DeleteDevTeam(string name)
        {
            DevTeam team = GetDevTeamByName(name);

            return _devTeams.Remove(team);

        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByName(string name)
        {
            foreach (DevTeam i in _devTeams)
            {
                if (i.Name.ToLower() == name.ToLower())
                {
                    return i;
                }
            }
            return null;
        }

    }
}
