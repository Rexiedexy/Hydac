using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Staff
    {
        Logger logger = new Logger();   
        private string[] name = { "Mark", "John", "Lisa", "Mona Lisa" }; // <= Navn
        private List<string> staffMembers = new List<string>();
        private int[] staffid = [2012, 1212, 2223, 3324]; // <= User ID
        private List<int> staffIDs = new List<int>();   
        private List<bool> staffStatus = new List<bool>(); // True = logged in, False = logged out
        private List<string> staffMood = new List<string>(); // Happy, Neutral, Angry

        public void StaffInit()
        {
            staffMembers.AddRange(name);
            staffIDs.AddRange(staffid); 
        }

        public void ShowStaff()
        {
            if(staffMembers.Count == 0)
            {
                Console.WriteLine("No staff members available.");
                return;
            }
            else
                foreach (var staff in staffMembers)
                    Console.WriteLine(staff);
        }
        public int getStaffID(string name)
        {
            int index = staffMembers.IndexOf(name);
            if (index != -1 && index < staffIDs.Count)  
                return staffIDs[index];
            else
                Console.WriteLine("Staff member not found.");   
            return -1;  
        }   

        private int getStaffIndex(int id) => staffIDs.IndexOf(id);  


        public void AddStaffStatus(string name, bool isLoggedIn)
        {
           int i = getStaffIndex(getStaffID(name));
           staffStatus[i] = isLoggedIn;    
           logger.Log($"Staff member {name} has logged {(isLoggedIn ? "in" : "out")}.");
        }

        public bool getStaffStatus(string name)
        {
            int i = getStaffIndex(getStaffID(name));
            return staffStatus[i];
        }   

        public void AddStaffMood(int selection, string name) // 1 = Happy, 2 = Neutral, 3 = Angry    
        {
            int i = getStaffIndex(getStaffID(name));
            if (selection == 1)
                staffMood[i]=("Happy");
            else if(selection == 2)
                staffMood[i] = ("Neutral");
            else if(selection == 3)
                staffMood[i] = ("Angry"); 
        }

        public string getStaffMood(string name)
        {
            int i = getStaffIndex(getStaffID(name));
            if(staffMood.Count != 0 && staffMood[i] != null)
                return staffMood[i];
            return ("not implemented yet"); 
        }   

    }
}
