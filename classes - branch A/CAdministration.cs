using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace BS_project2
{
    public class CAdministration:CUser
    {

        public CAdministration(String ID, String Name, String Pass, String Dep, String Per) :base(ID,Name,Pass,Dep,Per)
        {

        }
        public bool removeClass(string classID)
        {
            return Program.update_sql("DELETE classes WHERE Id='" + classID + "'");
        }
        public bool addClass(string id,int capacity,string acc,bool lab)
        {
            
            DataTable dt = Program.get_dt("SELECT Id from classes WHERE Id='" + id + "'");
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Class allready exist!");
                return false;
            }
            String query = "INSERT INTO classes VALUES ('" + id + "','" + capacity + "','" + acc + "','" + lab  + "')";
            return Program.update_sql(query);
           
        }
        public DataTable showDetails(string id)
        {
            return Program.get_dt("SELECT * from classes WHERE Id='" + id + "'");
            
        }
        public bool editClassDetails(String id,int capacity,string acc)
        {
            
               return Program.update_sql("UPDATE Classes SET Capacity = '" + capacity + "' WHERE Id ='" + id + "'") &&
                     Program.update_sql("UPDATE Classes SET Accessories = '" + acc + "' WHERE Id ='" + id + "'");
          


        }
        public bool addStudent(string id,string name,string department, string year)
        {
            

            if (id == "")
            {
                MessageBox.Show("Must enter ID!");
                return false;
            }
            if (name == "")
            {
                MessageBox.Show("Must enter name!");
                return false;
            }
            if (department == "")
            {
                MessageBox.Show("Must enter department!");
                return false;
            }
            if (year ==null)
            {
                MessageBox.Show("Invalid year!");
                return false;
            }
            DataTable dt = Program.get_dt("SELECT Id from students WHERE Id='" + id + "'");
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Id Already found in system!");
                return false;
            }
      
            return Program.update_sql("INSERT INTO students VALUES ('" + name + "','" + id + "','" + department + "','" + year + "','" + true + "')") && 
                 Program.update_sql("INSERT INTO Login VALUES ('" + id + "','" + name + "','" + "123456" + "','" + "Student" + "','" + department + "')");
          
        }
    }
}
