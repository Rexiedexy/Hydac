using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class AdminMembers
    {
        public string Name { get; private set; }
        public string ID { get; private set; }
        private string Password { get; }
        public bool IsLoggedIn { get; private set; }

        public AdminMembers(string name, string id, string pass)
        {
            Name = name;
            ID = id;
            IsLoggedIn = false;
            Password = pass;
        
        }

        public bool ValidatePassword(string password) => Password == password;


        public void SetLoginStatus(bool status) => IsLoggedIn = status;

        public override string ToString() =>
            $"Name: {Name}, ID: {ID}, Status: {(IsLoggedIn ? "Logged in" : "Logged out")}";
    }
}
