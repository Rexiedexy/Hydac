using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

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
        public string Name { get; init; }
        public int ID { get; init; }
        public bool IsLoggedIn { get; set; }
        public Mood Mood { get; set; }

        public StaffMember(string name, int id)
        {
            Name = name;
            ID = id;
            IsLoggedIn = false;
            Mood = Mood.Neutral;
        }

        public override string ToString() =>
            $"Name: {Name}, ID: {ID}, Status: {(IsLoggedIn ? "Logged in" : "Logged out")}, Mood: {Mood}";
    }

    public class Staff
    {
        private readonly Logger _logger = new Logger();
        private readonly ConcurrentDictionary<int, StaffMember> _staffMembers = new();
        private readonly ConcurrentDictionary<string, StaffMember> _staffByName =
            new(StringComparer.OrdinalIgnoreCase);

        public void StaffInit()
        {
            var initialStaff = new[]
            {
                new StaffMember("Mark", 2012),
                new StaffMember("John", 1212),
                new StaffMember("Lisa", 2223),
                new StaffMember("Mona Lisa", 3324),
                new StaffMember("Frank", 1012),
                new StaffMember("Bob", 1232),
                new StaffMember("Ole", 2923),
                new StaffMember("Johnnie", 3384)
            };

            foreach (var staff in initialStaff)
            {
                _staffMembers.TryAdd(staff.ID, staff);
                _staffByName.TryAdd(staff.Name, staff);
            }

            _logger.Log("Staff has been initialized.");
        }

        public void ShowStaff()
        {
            if (_staffMembers.IsEmpty)
            {
                _logger.Log("No staff to display.");
                Console.WriteLine("No staff members available.");
                return;
            }

            _logger.Log("Displaying all staff members...");

            Console.WriteLine($"{"Name",-15} {"ID",-6} {"Status",-12} {"Mood",-7}");
            Console.WriteLine(new string('-', 45));

            foreach (var staff in _staffMembers.Values.OrderBy(s => s.ID))
            {
                Console.WriteLine($"{staff.Name,-15} {staff.ID,-6} {(staff.IsLoggedIn ? "Logged in" : "Logged out"),-12} {staff.Mood,-7}");
                _logger.Log(staff.ToString());
            }
        }

        public void LogIn(string name) => SetStaffStatus(name, true);
        public void LogOut(string name) => SetStaffStatus(name, false);

        public bool? GetStaffStatus(string name)
        {
            if (!TryGetStaffByName(name, out var member))
            {
                _logger.Log($"{name} is not a valid staff member.");
                return null;
            }

            _logger.Log($"{name} is {(member.IsLoggedIn ? "logged in" : "logged out")}.");
            return member.IsLoggedIn;
        }

        public void SetStaffMood(string name, Mood mood)
        {
            if (!TryGetStaffByName(name, out var member))
            {
                _logger.Log($"{name} is not a valid staff member.");
                return;
            }

            lock (member)
            {
                var oldMood = member.Mood;
                member.Mood = mood;
                _logger.Log($"{name}'s mood changed from {oldMood} to {member.Mood}.");
            }
        }

        public bool TrySetStaffMood(string name, string moodString)
        {
            if (!Enum.TryParse<Mood>(moodString, true, out var mood))
            {
                _logger.Log($"Invalid mood input: {moodString}.");
                return false;
            }

            SetStaffMood(name, mood);
            return true;
        }

        public Mood? GetStaffMood(string name)
        {
            if (!TryGetStaffByName(name, out var member))
            {
                _logger.Log($"{name} is not a valid staff member.");
                return null;
            }

            _logger.Log($"{name}'s mood is {member.Mood}.");
            return member.Mood;
        }

        private void SetStaffStatus(string name, bool isLoggedIn)
        {
            if (!TryGetStaffByName(name, out var member))
            {
                _logger.Log($"{name} is not a valid staff member.");
                Console.WriteLine("Invalid staff member.");
                return;
            }

            lock (member)
            {
                member.IsLoggedIn = isLoggedIn;
            }

            _logger.Log($"{name} is now {(isLoggedIn ? "logged in" : "logged out")}.");
        }

        private bool TryGetStaffByName(string name, out StaffMember? member) =>
            _staffByName.TryGetValue(name, out member);

        private bool TryGetStaffById(int id, out StaffMember? member) =>
            _staffMembers.TryGetValue(id, out member);

        public int? GetStaffID(string name)
        {
            if (TryGetStaffByName(name, out var member))
            {
                _logger.Log($"ID of {name} is {member.ID}.");
                return member.ID;
            }

            _logger.Log($"{name} not found.");
            return null;
        }

        public string? GetStaffName(int id)
        {
            if (TryGetStaffById(id, out var member))
            {
                _logger.Log($"Name of staff with ID {id} is {member.Name}.");
                return member.Name;
            }

            _logger.Log($"No staff found with ID {id}.");
            return null;
        }
    }
}
