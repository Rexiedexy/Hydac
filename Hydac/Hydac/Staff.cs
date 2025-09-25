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
            IsLoggedIn = false;     // default
            Mood = Mood.Neutral;    // default
        }
    }

    public class Staff
    {
        private readonly Logger logger = new Logger();
        private readonly List<StaffMember> staffMembers = new List<StaffMember>();

        public void StaffInit()
        {
            staffMembers.Add(new StaffMember("Mark", 2012));
            staffMembers.Add(new StaffMember("John", 1212));
            staffMembers.Add(new StaffMember("Lisa", 2223));
            staffMembers.Add(new StaffMember("Mona Lisa", 3324));

            logger.Log("Staff initialized with default members.");
        }

        public void ShowStaff()
        {
            if (staffMembers.Count == 0)
            {
                logger.Log("No staff members available to show.");
                Console.WriteLine("No staff members available.");
                return;
            }

            logger.Log("Displaying full staff information:");
            foreach (var staff in staffMembers)
            {
                string status = staff.IsLoggedIn ? "Logged in" : "Logged out";
                string info = $"Name: {staff.Name}, ID: {staff.ID}, Status: {status}, Mood: {staff.Mood}";

                Console.WriteLine(info);
                logger.Log(info);
            }
        }


        public int GetStaffID(string name)
        {
            var member = staffMembers.Find(m => m.Name == name);
            if (member != null)
            {
                logger.Log($"Retrieved ID {member.ID} for staff member {name}.");
                return member.ID;
            }

            logger.Log($"Staff member '{name}' not found when requesting ID.");
            Console.WriteLine("Staff member not found.");
            return -1;
        }

        public void AddStaffStatus(string name, bool isLoggedIn)
        {
            var member = staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                logger.Log($"Attempted to set status for invalid staff member '{name}'.");
                Console.WriteLine("Invalid staff member.");
                return;
            }

            member.IsLoggedIn = isLoggedIn;
            logger.Log($"Staff member {name} has logged {(isLoggedIn ? "in" : "out")}.");
        }

        public bool GetStaffStatus(string name)
        {
            var member = staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                logger.Log($"Requested status for invalid staff member '{name}'.");
                return false;
            }

            logger.Log($"Staff member {name} status: {(member.IsLoggedIn ? "Logged in" : "Logged out")}.");
            return member.IsLoggedIn;
        }

        public void AddStaffMood(int selection, string name)
        {
            var member = staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                logger.Log($"Attempted to set mood for invalid staff member '{name}'.");
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

            logger.Log($"Staff member {name} mood changed from {oldMood} to {member.Mood}.");
        }

        public string GetStaffMood(string name)
        {
            var member = staffMembers.Find(m => m.Name == name);
            if (member == null)
            {
                logger.Log($"Requested mood for invalid staff member '{name}'.");
                return "not implemented yet";
            }

            logger.Log($"Staff member {name} mood retrieved: {member.Mood}.");
            return member.Mood.ToString();
        }
    }
}
