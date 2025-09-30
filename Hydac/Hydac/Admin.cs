﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hydac
{
    public class Admin
    {
        private List<Guest> guests = new List<Guest>();
        private Logger logger;
        private readonly ConcurrentDictionary<int, StaffMember> _staffMembers = new();
        private readonly ConcurrentDictionary<string, StaffMember> _staffByName =
            new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, AdminMembers> _adminMembers = new();
        private readonly ConcurrentDictionary<string, AdminMembers> _adminByName =
            new(StringComparer.OrdinalIgnoreCase);
        
        public Admin(Logger log)
        {
            logger = log;
        }


        //Admins
        public void AdminInit()
        {
            var initialAdmin = new[]
            {
               new AdminMembers("Jacob", "A27", "admin123"),
               new AdminMembers("Børge", "A22", "admin123")

            };

            foreach (var admin in initialAdmin)
            {
                _adminMembers.TryAdd(admin.ID, admin);
                _adminByName.TryAdd(admin.Name, admin);
            }

            logger.Log("Admins has been initialized.");
        }

        //GUEST MANAGEMENT
        public void AddGuest(string id, string name, string companyname)
        {
            if (!IsValidName(name))
            {
                Console.WriteLine("Invalid name! Name cannot contain numbers or special characters.");
                return;
            }

            guests.Add(new Guest(id, name, companyname, logger));
            Console.WriteLine($"Guest {name} ({companyname}) added successfully.");
        }
        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }


        public void CheckGuestById(string id)
        {
            var guest = guests.Find(g => g.GuestId == id);
            if (guest == null)
            {
                Console.WriteLine("Guest not found!");
                return;
            }

            Console.WriteLine("1. Check In");
            Console.WriteLine("2. Check Out");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                guest.CheckIn();
            else if (choice == "2")
                guest.CheckOut();
            else
                Console.WriteLine("Invalid choice.");
        }

        /*public void ShowAllGuests()
        {
            foreach (var g in guests)
            {
                Console.WriteLine($"{g.Name} ({g.CompanyName}) [ID: {g.GuestId}] - {(g.IsCheckedIn ? "Checked In" : "Checked Out")}");
            }
        }*/
        public bool RemoveGuest(string id)
        {
            var guest = guests.Find(g => g.GuestId == id);
            if (guest != null)
            {
                guests.Remove(guest);
                logger.Log($"Guest {guest.Name} ({guest.CompanyName}) [ID: {guest.GuestId}] has been removed.");
                return true;
            }
            return false;

        }



        //STAFF MANAGEMENT
        public bool AddStaff(string name, int ID, string Pass)
        {
            var m = new StaffMember(name, ID, Pass);
            if (_staffMembers.TryAdd(m.ID, m) && _staffByName.TryAdd(m.Name, m))
            {
                logger.Log($"{m.Name} Has Been Added As A Staffmember");
                return true;
            }
            else
                logger.Log($"{name} Could Not Be Added As A Staffmember");
            m = null;
            return false;
        }


        public bool? RemoveStaff(string name, int ID, string Pass)
        {
            if (!TryGetStaffById(ID, out var member))
            {
                logger.Log($"ID {ID} is not a valid staff member.");
                Console.WriteLine("Invalid staff member.");
                return null;
            }
            if (!member!.ValidatePassword(Pass))
            {
                logger.Log($"Wrong password for {member.Name} (ID {member.ID}).");
                Console.WriteLine("Invalid Password");
                return null;
            }
            if (!TryGetStaffByName(name, out var member1))
            {
                logger.Log($"{name} is not a valid staff member.");
                return false;
            }
            if (_staffMembers.TryRemove(member.ID, out member) && _staffByName.TryRemove(member.Name, out member))
            {
                member = null;
                logger.Log($"{name} Has Been Removed As A Staffmember");
                return true;
            }

            return false;
        }
        private bool TryGetStaffByName(string name, out StaffMember? member) =>
            _staffByName.TryGetValue(name, out member);

        private bool TryGetStaffById(int id, out StaffMember? member) =>
            _staffMembers.TryGetValue(id, out member);
    }
}

