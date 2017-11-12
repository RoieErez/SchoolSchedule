using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BS_project2
{
    class Courses
    {
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string ID;
        private string name;
        private string day;
        private string startH;
        private string endH;
        private string className;
        private string type;
        private string lessonID;
        private string lecturer;
        private int capacity;
        private string preCourse;
        private bool passPreCourse;

        public Courses(string ID, string name, string day, string startH, string endH, string className, string type, string lessonID, string lecturer, string pre, string studentID)
        {
            this.ID = ID;
            this.name = name;
            this.day = day;
            this.startH = startH;
            this.endH = endH;
            this.className = className;
            this.type = type;
            this.lessonID = lessonID;
            checkLecturer(lecturer);
            this.capacity = 0;
            checkCourseID(pre, studentID);
        }

        private void checkCourseID(string pre, string studentID)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Courses";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
                if (dr["Pre"].Equals(pre))
                {
                    this.preCourse = dr["Id"].ToString();
                    passPreCourse = checkIfPass(studentID);
                    break;
                }
                else
                {
                    this.preCourse = null;
                    this.passPreCourse = true;
                }
            conn.Close();
        }

        private bool checkIfPass(string studentID)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from StudentOldCourses";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
                if (dr2["StudentID"].Equals(studentID) && dr2["CourseID"].Equals(this.ID))
                    if ((int)(dr2["Grade"]) >= 56)
                    {
                        conn.Close();
                        return true;
                    }
            conn.Close();
            return false;
        }

        private void checkLecturer(string lecturer)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Login";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);

            foreach (DataRow dr3 in dt3.Rows)
                if (dr3["Id"].Equals(lecturer))
                {
                    setLecturer(dr3["F_Name"].ToString());
                    break;
                }
            conn.Close();
        }

        public int getCapacity()
        {
            return this.capacity;
        }

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public string getLecturer()
        {
            return this.lecturer;
        }

        public void setLecturer(string lecturer)
        {
            this.lecturer = lecturer;
        }

        public string getLessonID()
        {
            return this.lessonID;
        }

        public string getName()
        {
            return this.name;
        }

        public int getStartH()
        {
            switch (startH)
            {
                case "8:00":
                    return 0;
                case "9:00":
                    return 1;
                case "10:00":
                    return 2;
                case "11:00":
                    return 3;
                case "12:00":
                    return 4;
                case "13:00":
                    return 5;
                case "14:00":
                    return 6;
                case "15:00":
                    return 7;
                case "16:00":
                    return 8;
                case "17:00":
                    return 9;
                case "18:00":
                    return 10;
                case "19:00":
                    return 11;
                default:
                    return 0;
            }
        }

        public int getEndH()
        {
            switch (endH)
            {
                case "8:00":
                    return 0;
                case "9:00":
                    return 1;
                case "10:00":
                    return 2;
                case "11:00":
                    return 3;
                case "12:00":
                    return 4;
                case "13:00":
                    return 5;
                case "14:00":
                    return 6;
                case "15:00":
                    return 7;
                case "16:00":
                    return 8;
                case "17:00":
                    return 9;
                case "18:00":
                    return 10;
                case "19:00":
                    return 11;
                default:
                    return 0;
            }
        }
        public int getDay()
        {
            switch (day)
            {
                case "Sunday":
                    return 0;
                case "Monday":
                    return 1;
                case "Tuesday":
                    return 2;
                case "Wednesday":
                    return 3;
                case "Thursday":
                    return 4;
                case "Friday":
                    return 5;
                default:
                    return 0;
            }
        }

        public string getID()
        {
            return this.ID;
        }

        public string getClassName()
        {
            return this.className;
        }

        public string getType()
        {
            return this.type;
        }

        public string getPre()
        {
            return this.preCourse;
        }

        public bool getPassPreCourse()
        {
            return passPreCourse;
        }
    }
}
