using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data;

namespace BS_project2
{
    public class Student : User
    {
        static Random obj = new Random();
        private string department;
        private string semester;
        private bool active;
        private float totalPoints;
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Student(string ID, string name, string pass, string department, string semester, bool active) : base(ID, name,pass) {
            this.department = department;
            this.semester = semester;
            this.active = active;
        }

        public string getDep()                  {return this.department; }

        public float getTotalPoints() { return this.totalPoints; }
        public string getSemester()             { return this.semester; }
        public bool getStatus()                 { return this.active; }
        public bool Changestudentdetails()
        {
            return true;
        }
        public bool Check_InPut(String input)
        {
            if (input.Length > 1)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Contains(" ") == true || input[i].ToString() == "_" || input.Any(char.IsDigit) == true)//Input check
                        return false;
                }
                return true;
            }
            else
                return false;

        }
        public bool changedetailbutton(string firstbame,string lastname, SqlConnection con)
        {
            con.Open();
            if(Program.update_sql("UPDATE Students SET Name='" + firstbame + " " + lastname + "'" + "where ID='" + getID() + "'"))
            {
                setName(firstbame + " " + lastname);
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public bool createrandompassword(SqlConnection con)
        {
            con.Open();
            String randompassword = GetRandomPassword();
            if (Program.update_sql("UPDATE Login SET password ='" + randompassword + "'" + "WHERE id ='" + getID() + "'")==true)
            {
                MessageBox.Show("your new password is :" + randompassword, "Random Password");
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public static string GetRandomPassword()//makes a random password 
        {
            return obj.Next(10000, 99999).ToString();
        }

        public bool deleteALL()        //  DELETE ALL COURSES OF THE CURRENT SEMESTER
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from student_schedule";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["StudentID"].Equals(getID()))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM student_schedule WHERE StudentID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", getID());
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
            return true;
        }

        public float calcTotalPoints()
        {
            this.totalPoints = 0;

            //String connect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(this.constring);
            String query = "Select * from StudentOldCourses where StudentID = '" + this.getID() + "'"; //and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int grade = (int)(dr["Grade"]);
                    float Points;
                    if (grade > 55)
                    {
                        SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Courses where id = '" + dr["CourseID"] + "'", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            Points = float.Parse(dr2["Points"].ToString());
                            this.totalPoints += Points;
                        }


                    }
                }
            }
            return this.totalPoints;
        }
    }
    
}
