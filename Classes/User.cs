using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BS_project2
{
    public abstract class User
    {
        protected string ID;
        protected string name;
        protected string pass;

        //public string id { set { ID = value; } get { return ID; } }



        public User(string ID, string name, string pass)
        {
            this.ID = ID;
            this.name = name;
            this.pass = pass;
        }

        public string getID() { return this.ID; }

        public string getName() { return this.name; }

        public string getPass() { return this.pass; }

        public bool setID(string ID)
        {
            if (ID.Length>0)
            {
                this.ID = ID;
                return true;
            }
            else
                return false;
        }

        public bool setName(string name)
        {
            if (name.Length > 0)
            {
                this.name = name;
                return true;
            }
            else
                return false;
        }

        public bool setPass(string pass)
        {
            if (pass.Length > 0)
            {
                this.pass = pass;
                return true;
            }
            else
                return false;
        }

        public bool changePass(string old, string new1, string new2)
        {
            if (new1 != new2) return false;
            if (old != this.pass) return false;
            if (old == new1) return false;
            this.pass = new1;

            SqlConnection con = new SqlConnection("Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Login SET Password='" + new1 + "'" + " WHERE Id='" + this.ID + "'", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}
