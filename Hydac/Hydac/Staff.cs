using System;
using System.Collections.Generic;

namespace Hydac
{
    public enum Mood
    {
        Happy,
        Neutral,
        Angry
    }

    public class StaffMember
    {
        public string Name { get; }
        public int ID { get; }
        public bool IsLoggedIn { get; set; }
        public Mood Mood { get; set; }

        public StaffMember(string name, int id)
        {
            Name = name;
            ID = id;
            IsLoggedIn = false;
            Mood = Mood.Neutral;
        }
    }

    public class Staff
    {
        private readonly Logger _logger = new Logger();
        private readonly List<StaffMember> _staffMembers = new List<StaffMember>();

        public void StaffInit()
        {
            _staffMembers.Add(new StaffMember("Mark", 2012));
            _staffMembers.Add(new StaffMember("John", 1212));
            _staffMembers.Add(new StaffMember("Lisa", 2223));
            _staffMembers.Add(new StaffMember("Mona Lisa", 3324));
            _staffMembers.Add(new StaffMember("Frank", 1012));
            _staffMembers.Add(new StaffMember("Bob", 1232));
            _staffMembers.Add(new StaffMember("Ole", 2923));
            _staffMembers.Add(new StaffMember("Johnnie", 3384));
            _logger.Log("Staff has been set up.");
        }

        public void ShowStaff()
        {
            if (_staffMembers.Count == 0)
            {
                _logger.Log("No staff to show.");
                Console.WriteLine("No staff members available.");
                return;
            }

            _logger.Log("Showing all staff:");
            foreach (var staff in _staffMembers)
            {
                string status = staff.IsLoggedIn ? "Logged in" : "Logged out";
                string info = $"Name: {staff.Name}, ID: {staff.ID}, Status: {status}, Mood: {staff.Mood}";
                Console.WriteLine(info);
                _logger.Log(info);
            }
        }

        public int GetStaffID(string name)
        {
            var member = _staffMembers.Find(m => m.Name == name);
            if (member != null)
            {
                _logger.Log($"ID of {name} is {member.ID}.");
                return member.ID;
            }

            _logger.Log($"{name} not found.");
            Console.WriteLine("Staff member not found.");
            return -1;
        }
        public string GetStaffName(int id)
        {
            var member = _staffMembers.Find(m => m.ID == id);
            if (member != null)
            {
                _logger.Log($"Name of staff with ID {id} is {member.Name}.");
                return member.Name;
            }

            _logger.Log($"No staff found with ID {id}.");
            return "Not found";
        }


        public void AddStaffStatus(string name, bool isLoggedIn)
        {
            var member = _staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                _logger.Log($"{name} is not a valid staff member.");
                Console.WriteLine("Invalid staff member.");
                return;
            }

            member.IsLoggedIn = isLoggedIn;
            _logger.Log($"{name} is now {(isLoggedIn ? "logged in" : "logged out")}.");
        }

        public bool GetStaffStatus(string name)
        {
            var member = _staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                _logger.Log($"{name} is not a valid staff member.");
                return false;
            }

            _logger.Log($"{name} is {(member.IsLoggedIn ? "logged in" : "logged out")}.");
            return member.IsLoggedIn;
        }

        public void AddStaffMood(int selection, string name)
        {
            var member = _staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                _logger.Log($"{name} is not a valid staff member.");
                return;
            }

            var oldMood = member.Mood;
            member.Mood = selection switch
            {
                1 => Mood.Happy,
                2 => Mood.Neutral,
                3 => Mood.Angry,
                _ => member.Mood
            };

            _logger.Log($"{name}'s mood changed from {oldMood} to {member.Mood}.");
        }

        public string GetStaffMood(string name)
        {
            var member = _staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                _logger.Log($"{name} is not a valid staff member.");
                return "not implemented yet";
            }

            _logger.Log($"{name}'s mood is {member.Mood}.");
            return member.Mood.ToString();
        }
    }
}
