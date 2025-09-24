using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Admin
    {
        private string[] name = {"Børge", "Jacob", };
        private List<string> adminMembers = new List<string>();
        private string[] adminId = {"A22", "A27"};

        public Admin(string name, string adminId)
        {
            this.name = name;
            this.adminId = adminId;
        }
        public string Name { get { return name; } }
        public string AdminId { get { return adminId; } }

    }
}
