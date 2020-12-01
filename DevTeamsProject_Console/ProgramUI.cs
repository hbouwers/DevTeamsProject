using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject_Console
{
    class ProgramUI
    {
        private DevTeamRepo _teamsRepo = new DevTeamRepo();
        private DeveloperRepo _devRepo = new DeveloperRepo();
        private int count = 3;

        // Method that runs/starts the app
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine(
                    "Select a menu option:\n" +
                    "1. Create New Dev Team\n" +
                    "2. View Dev Teams\n" +
                    "3. View Dev Team By Name\n" +
                    "4. Update Dev Team\n" +
                    "5. Delete Dev Team\n" +
                    "6. Create New Developer\n" +
                    "7. View All Developers\n" +
                    "8. View Developer\n" +
                    "9. Delete Developer\n" +
                    "10. Add Developer to Team\n" +
                    "11. Exit\n"
                    );

                // Get user's  input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new dev team
                        CreateNewDevTeam();
                        break;
                    case "2":
                        // View all content
                        DisplayDevTeams();
                        break;
                    case "3":
                        // View dev team by name
                        DisplayDevTeamByName();
                        break;
                    case "4":
                        // Update dev team
                        UpdateDevTeam();
                        break;
                    case "5":
                        // Delete dev team
                        DeleteDevTeam();
                        break;
                    case "6":
                        // Create dev
                        CreateDeveloper();
                        break;
                    case "7":
                        // View all devs
                        DisplayAllDevelopers();
                        break;
                    case "8":
                        // view dev by 
                        DisplayDeveloper();
                        break;
                    case "9":
                        // Delete dev
                        DeleteDeveloper();
                        break;
                    case "10":
                        // Add dev to team
                        AddDeveloperToTeam();
                        break;
                    case "11":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-10");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // Create New Dev Team
        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the name of the team");
            newTeam.Name = Console.ReadLine();

            _teamsRepo.AddDevTeam(newTeam);
        }

        // View Dev Teams
        private void DisplayDevTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _teamsRepo.GetDevTeams();

            foreach (DevTeam i in devTeams)
            {
                Console.WriteLine($"Team Name: {i.Name}");
            }
        }

        // View Dev Team By Name
        private void DisplayDevTeamByName()
        {
            // Display all team names
            DisplayDevTeams();
            Console.WriteLine("Enter the name of the team you would like to view");

            // Get user input
            string name = Console.ReadLine();

            // Get team by name
            DevTeam team = _teamsRepo.GetDevTeamByName(name);

            if (team == null)
            {
                Console.WriteLine("No team found by that name");
            }
            else if (team._developers.Count > 0)
            {
                foreach (Developer i in team._developers)
                {
                    Console.WriteLine(i.Name);
                }
            }
            else
            {
                Console.WriteLine("There are no developers on that team");
            }

        }

        // Update Dev Team
        private void UpdateDevTeam()
        {
            // Display Dev Teams
            DisplayDevTeams();
            Console.WriteLine("Enter the name of the team you would like to update");

            // User input name of team to update
            string name = Console.ReadLine();
            Console.Clear();

            // New Name
            Console.WriteLine("Enter the new name");
            string newName = Console.ReadLine();

            bool success = _teamsRepo.UpdateDevTeam(newName);

            if (success)
            {
                Console.WriteLine("Dev Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Dev Team");
            }
        }

        // Delete Dev Team
        private void DeleteDevTeam()
        {
            DisplayDevTeams();

            // Prompt user for team to delete
            Console.WriteLine("\nEnter the name of the team you would like to delete");
            // User input
            string name = Console.ReadLine();
            // Find team
            DevTeam team = _teamsRepo.GetDevTeamByName(name);
            // Delete content if not null
            bool success = _teamsRepo.DeleteDevTeam(team.Name);
            if (success)
            {
                Console.WriteLine("Team deleted");
            }
            else
            {
                Console.WriteLine("There was a problem");
            }
        }

        // Get Id
        private int GetId()
        {
            count += 1;
            return count;
        }

        // Create Developer
        private void CreateDeveloper()
        {
            Console.Clear();
            // Create new Developer Object
            Developer newDev = new Developer();

            newDev.Id = GetId();
            //Get user input
            Console.WriteLine("Enter the developers name");
            newDev.Name = Console.ReadLine();
            Console.WriteLine("Enter the email");
            newDev.Email = Console.ReadLine();
            Console.WriteLine("Enter the salary (only numbers)");
            newDev.Salary = int.Parse(Console.ReadLine());

            bool needValidInput = true;
            while (needValidInput)
            {
                Console.WriteLine("Do they have access to Pluralsight?(y/n)");
                string hasAccess = Console.ReadLine().ToLower();
                if (hasAccess == "y")
                {
                    newDev.AccessToPluralsight = true;
                    needValidInput = false;
                }
                else if (hasAccess == "n")
                {
                    newDev.AccessToPluralsight = false;
                    needValidInput = false;
                }
            }

            _devRepo.AddDeveloper(newDev);
        }

        // Display All Developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> devs = _devRepo.GetDevelopers();

            foreach (Developer i in devs)
            {
                Console.WriteLine($"{i.Id}: {i.Name}");
            }
        }

        // Add Developer to a team
        private void AddDeveloperToTeam()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Enter the id of the developer you would like to see");
            int input = int.Parse(Console.ReadLine());

            // get developer by id
            Developer dev = _devRepo.GetDeveloperById(input);

            DisplayDevTeams();
            Console.WriteLine($"Enter the name of the team to which you would like to add {dev.Name}");
            string name = Console.ReadLine();
            DevTeam team = _teamsRepo.GetDevTeamByName(name);
            // AddDevToTeamById returns a string - team not found or added successfully
            string message = _teamsRepo.AddDevToTeamById(dev, team.Name);
            Console.WriteLine(message);
        }

        // Display Developer By Id
        private void DisplayDeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Enter the id of the developer you would like to see");
            int input = int.Parse(Console.ReadLine());

            // get developer by id
            Developer dev = _devRepo.GetDeveloperById(input);

            Console.WriteLine($"Id: {dev.Id}, Name {dev.Name}, Salary: {dev.Salary}, Email: {dev.Email}, Access to Pluralsight: {dev.AccessToPluralsight}");
        }

        // Delete Developer
        private void DeleteDeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Enter the id of the developer you would like to delete");
            int input = int.Parse(Console.ReadLine());
            bool success = _devRepo.DeleteDeveloper(input);
            if (success)
            {
                Console.WriteLine("Developer successfully deleted");
            }
            else
            {
                Console.WriteLine("There was a problem deleting the developer");
            }
        }

        // Seed method
        private void SeedContentList()
        {
            // add some teams
            DevTeam java = new DevTeam("Javamen"); // People that like to coffee and code
            DevTeam python = new DevTeam("Pythonmen"); // People that like reptiles can't be trusted
            DevTeam c = new DevTeam("C-bois"); // Also known as sailors

            _teamsRepo.AddDevTeam(java);
            _teamsRepo.AddDevTeam(python);
            _teamsRepo.AddDevTeam(c);

            // add some devs
            Developer sirSmith = new Developer(1, "Renaldo Smith", "rsmith@gmail.com", 50000, true);
            Developer sirNorington = new Developer(2, "Wiliam Norington", "2hot2touch83@gmail.com", 80000, false);
            Developer sirVanlicktenstien = new Developer(3, "Oric VanLicktenstein", "rickyV@gmail.com", 20000, false);

            _devRepo.AddDeveloper(sirSmith);
            _devRepo.AddDeveloper(sirNorington);
            _devRepo.AddDeveloper(sirVanlicktenstien);

            // add devs to teams
            _teamsRepo.AddDevToTeamById(sirSmith, java.Name);
            _teamsRepo.AddDevToTeamById(sirNorington, java.Name);
            _teamsRepo.AddDevToTeamById(sirVanlicktenstien, python.Name);
        }
    }
}

