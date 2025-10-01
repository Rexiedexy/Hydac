using System;
using System.Collections.Concurrent;
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
        public string Name { get; private set; }
        public int ID { get; private set; }
        private string PassWord { get; }
        public bool IsLoggedIn { get; private set; }
        public Mood Mood { get; private set; }

        public StaffMember(string name, int id, string pass)
        {
            Name = name;
            ID = id;
            IsLoggedIn = false;
            PassWord = pass;
            Mood = Mood.Neutral;
        }

        public bool ValidatePassword(string password) => PassWord == password;

        public void SetMood(Mood mood) => Mood = mood;

        public void SetLoginStatus(bool status) => IsLoggedIn = status;

        public override string ToString() =>
            $"Name: {Name}, ID: {ID}, Status: {(IsLoggedIn ? "Logged in" : "Logged out")}, Mood: {Mood}";
    }

    public class Staff
    {
        private readonly Logger _logger = new Logger();
        public static readonly ConcurrentDictionary<int, StaffMember> _staffMembers = new();
        public static readonly ConcurrentDictionary<string, StaffMember> _staffByName =
            new(StringComparer.OrdinalIgnoreCase);

        public void StaffInit()
        {
            var initialStaff = new[]
            {
                new StaffMember("Mikkel", 4821, "solkat"),
                new StaffMember("Freja", 9132, "hus123"),
                new StaffMember("Søren", 7284, "morgen7"),
                new StaffMember("Ida", 6043, "katte1"),
                new StaffMember("Lars", 8520, "vand88"),
                new StaffMember("Emil", 1765, "træhus"),
                new StaffMember("Tilde", 4399, "sommer2"),
                new StaffMember("Anker", 2910, "cykel9")

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
                Console.Write($"{staff.Name,-15} {staff.ID,-6} {(staff.IsLoggedIn ? "Logged in" : "Logged out"),-12} ");
                switch (staff.Mood)
                {
                    case Mood.Happy:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Mood.Angry:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine($"{staff.Mood,-7}");
                Console.ResetColor();
                _logger.Log(staff.ToString());
            }
        }
        public StaffMember? LogIn(int id, string pass) => SetStaffStatus(id, pass, true);

        public StaffMember? LogOut(int id, string pass) => SetStaffStatus(id, pass, false);

        public bool SetStaffMood(string name, Mood mood)
        {
            if (!TryGetStaffByName(name, out var member))
            {
                _logger.Log($"{name} is not a valid staff member.");
                return false;
            }
            if (!member!.IsLoggedIn)
            {
                _logger.Log($"{name} must be logged in to change mood.");
                Console.WriteLine($"{name} must be logged in to change mood.");
                return false;
            }
            member.SetMood(mood);
            _logger.Log($"{name}'s mood changed to {member.Mood}.");
            return true;
        }

        private StaffMember? SetStaffStatus(int id, string pass, bool isLoggedIn)
        {
            if (!TryGetStaffById(id, out var member))
            {
                _logger.Log($"ID {id} is not a valid staff member.");
                Console.WriteLine("Invalid staff member.");
                return null;
            }

            if (!member!.ValidatePassword(pass))
            {
                _logger.Log($"Wrong password for {member.Name} (ID {member.ID}).");
                Console.WriteLine("Invalid Password");
                return null;
            }
            member.SetLoginStatus(isLoggedIn);

            _logger.Log($"{member.Name} is now {(isLoggedIn ? "logged in" : "logged out")}.");
            return member;
        }

        private bool TryGetStaffByName(string name, out StaffMember? member) =>
            _staffByName.TryGetValue(name, out member);

        private bool TryGetStaffById(int id, out StaffMember? member) =>
            _staffMembers.TryGetValue(id, out member);
    }
}