using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS_project2.Classes;


namespace BS_project2
{
    public class Secretary : User
    {
        private string department;

        public Secretary(string ID, string name, string pass, string department) : base(ID, name, pass)
        {
            this.department = department;
        }

        public string getDepartment() { return this.department; }

        public bool setDepartment(string department)
        {
            if(department.Length>0)
            {
                this.department = department;
                return true;
            }
            return false;
        }

    }
}

