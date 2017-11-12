using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace BS_project2
{
    public class CHeadOfDepartment:CUser
    {
        public CHeadOfDepartment(string id,string name,string pass,string dep,string per) :base(id,name,pass,dep,per){/*constructor*/ }

        public bool DismissTeachingStaff(string id)
        {/*dismiss teaching staff and remove from data base*/
            DataTable dt = Program.get_dt("SELECT Id from Teaching_staff WHERE Id='" + id + "'");
            if (dt.Rows.Count == 0)
                return false;

            /*success*/
            return Program.update_sql("DELETE Teaching_staff WHERE Id='" + id + "'") &&
            Program.update_sql("DELETE Login WHERE Id='" + id + "'") &&
            Program.update_sql("delete lecturer_prac_assignment where id='" + id + "'");
        }
        public bool AddTeachingStaff(String IDText,String NameText, CheckBox lecturer, CheckBox practioner)
        {
            /*add teaching staff to data base*/
            string type;
            if (IDText== "")
            {
                MessageBox.Show("Must enter ID!");
                return false;
            }
            if (NameText == "")
            {
                MessageBox.Show("Must enter name!");
                return false;
            }
            if (lecturer.CheckState == CheckState.Checked && practioner.CheckState == CheckState.Unchecked)
                type = "Lecturer";
            else if (practioner.CheckState == CheckState.Checked && lecturer.CheckState == CheckState.Unchecked)
                type = "Practioner";
            else
            {
                MessageBox.Show("Must choose exacly one type!");
                return false;
            }
            DataTable dt = Program.get_dt("SELECT Id from Teaching_staff WHERE Id='" + IDText + "'");
            if (dt.Rows.Count != 0)
            {
                return false;
            }
            String query = "INSERT INTO Login VALUES ('" + IDText + "','" + NameText + "','" + "123456" + "'," + "'TS'" + ",'" + Department + "','null')";
            /*Add to login and teaching_staff tables*/
            if (Program.update_sql(query) && Program.update_sql("INSERT INTO Teaching_staff (Id,Type) VALUES ('" + IDText + "','" + type + "')"))
                /*succeses*/
                return true;
            /*Something worngs*/
            return false;
        }
        public bool addSecretary(String IDText,String NameText)
        { /*add sercretary to data base*/
            if (IDText == "")
            {
                MessageBox.Show("Must enter ID!");
                return false;
            }
            if (NameText == "")
            {
                MessageBox.Show("Must enter name!");
                return false;
            }
            DataTable dt = Program.get_dt("SELECT Id from Login WHERE Id='" + IDText + "'");
            if (dt.Rows.Count != 0)
            {
                return false;
            }
            String query = "INSERT INTO Login VALUES ('" + IDText + "','" + NameText + "','" + "123456" + "'," + "'SEC'" + ",'" + Department + "','null')";
            if(Program.update_sql(query))
                return true;
            return false;
        }
        public bool showCourseDetails(string semester,ListView l)
        {
            /*Show details*/
            DataTable dt = Program.get_dt("SELECT name,points from Courses WHERE Semester='" + semester + "'and department='" + Department + "'");

            ListViewItem item;
            if (dt.Rows.Count < 1)
                return false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               item = new ListViewItem(dt.Rows[i][0].ToString());
               item.SubItems.Add(dt.Rows[i][1].ToString());
               l.Items.Add(item);
            }
            return true;
         
        }
        public bool showStudentsDetails(string semester, ListView l)
        {

            DataTable dt = Program.get_dt("SELECT Name,Active from Students WHERE Department='"+this.Department+"'and Semester='" + semester + "'");
            ListViewItem item;
            if (dt.Rows.Count < 1)
                return false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                item = new ListViewItem(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                l.Items.Add(item);

            }
            return true;

        }
        public bool dismissSecretary(string id)
        {/*dismiss sercretary and remove from data base*/
            DataTable dt = Program.get_dt("SELECT Id from Login WHERE Id='" + id + "'");
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            if (Program.update_sql("DELETE Login WHERE Id='" + id + "'"))
                /*succsses*/
                return true;
            /*not found*/
            return false; 
        }
        public bool AddLecturer_PracAssignment(String courseid, String id)
        {
            /*alrady exisst*/
            DataTable t = Program.get_dt("SELECT * FROM Lecturer_prac_assignment WHERE Courseid='" + courseid + "' and Id='"+id+"'");
            if(t.Rows.Count==0)
                return Program.update_sql("INSERT INTO Lecturer_prac_assignment VALUES('" + courseid + "','" + id + "')");
            return false;
        }
        public bool ShowTSAssignment( ListView l,string id)
        {
            DataTable dt, t;
            
          
            dt = Program.get_dt("Select CourseId From Lecturer_prac_Assignment where Id = '" + id + "'");/*courses id*/
            if (dt.Rows.Count < 1)
                return false;
            t = Program.get_dt("Select Id,Name,Points,Semester From Courses");/*courses*/
            ListViewItem item;
            for ( int i=0; i<dt.Rows.Count;i++)
            {
                for (int j=0;j<t.Rows.Count;j++)
                {
                    if(dt.Rows[i][0].ToString().Equals(t.Rows[j][0].ToString()))
                    {
                        item = new ListViewItem(t.Rows[i][1].ToString());
                        item.SubItems.Add(t.Rows[i][2].ToString());
                        item.SubItems.Add(t.Rows[i][3].ToString());
                        l.Items.Add(item);
                    }
                }
            }
            if (l.Items.Count == 0)
                return false;

            return true;
        }



    }
}
