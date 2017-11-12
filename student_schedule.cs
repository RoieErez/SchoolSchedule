using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS_project2.Classes;
using System.Data.SqlClient;
namespace BS_project2

{
    public partial class student_schedule : Form
    {
        Courses[] courses;
        Button[,] buttonArray = new Button[6, 12];
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        Student student;
        DataTable tabletoshow = new DataTable();

        public Form RefToLastForm { get; set; }
        public student_schedule(Student temp)
        {
            InitializeComponent();
            student = temp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void student_schedule_Load(object sender, EventArgs e)
        {
            // start build schedule

            int top = 50, index = 0;
            int left = 100;
            int i, j, counter = 0;
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Click += new System.EventHandler(ClickedButton);
                    buttonArray[i, j].Size = new Size(120, 40);
                    buttonArray[i, j].Left = left;
                    buttonArray[i, j].Top = top;
                    this.Controls.Add(buttonArray[i, j]);
                    top += buttonArray[i, j].Height + 2;
                }
                top = 50;
                left += 125;
            }

            // finish build schedule visualy

            //load the schedule of the student
            //----------------------------------------------

            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd0 = conn.CreateCommand();
            cmd0.CommandType = CommandType.Text;
            cmd0.CommandText = "select * from student_schedule";
            cmd0.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter da0= new SqlDataAdapter(cmd0);
            da0.Fill(dt0);

            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Courses";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Lessons";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            foreach (DataRow dr0 in dt0.Rows)
            {
                if (dr0["StudentID"].Equals(student.getID()))
                {
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (dr0["LessonID"].Equals(dr2["LessonID"].ToString()))
                        {
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                if (dr2["CourseID"].Equals(dr1["Id"].ToString()))
                                {
                                    Courses temp = new Courses(dr2["CourseID"].ToString(), dr1["Name"].ToString(), dr2["Day"].ToString(), dr2["StartH"].ToString(), dr2["EndH"].ToString(), dr2["ClassName"].ToString(), dr2["LessonType"].ToString(), dr2["LessonID"].ToString(), dr2["TSID"].ToString(), dr1["Pre"].ToString(), student.getID());
                                    index++;
                                    for (int k = temp.getStartH(); k < temp.getEndH(); k++)
                                        buttonArray[temp.getDay(), k].Text = temp.getName() + " " + temp.getType();
                                    buttonArray[temp.getDay(), temp.getStartH()].Height = buttonArray[temp.getDay(), temp.getStartH()].Height * (temp.getEndH() - temp.getStartH()) + 2 * (temp.getEndH() - temp.getStartH() - 1);
                                    buttonArray[temp.getDay(), temp.getStartH()].Text =temp.getName()+" "+temp.getType();
                                }
                            }
                        }
                    }
                }
            }

             //----------------------------------------------

            //-------------------------------------------------------
            //load combobox - courses that student able to register 

            // getting the courses by semester and department into combobox1
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();

            foreach (DataRow dr2 in dt2.Rows)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (student.getDep().Equals(dr["Department"]) && student.getSemester().Equals(dr["Semester"]))
                        if (dr["Id"].ToString().Equals(dr2["CourseID"]))
                        {
                            {
                                if(checkifclassisfull(dr2["LessonID"].ToString())==1)
                                {
                                    comboBox1.Items.Add(dr["Name"].ToString() + " " + dr2["LessonType"]);
                                    comboBox2.Items.Add(dr["Name"].ToString() + " " + dr2["LessonType"]);
                                    counter++;
                                }
                            }
                        }
                }
            }
            courses = new Courses[counter];
            i = 0;

            // fill courses array with courses that the student can learn

            j = 0;
            foreach (DataRow dr2 in dt2.Rows)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (student.getDep().Equals(dr["Department"]) && student.getSemester().Equals(dr["Semester"]))
                        if (dr["Id"].ToString().Equals(dr2["CourseID"]))
                        {
                            for (j = 0; j < i; j++)
                                if (courses[j].getLessonID().Equals(dr2["LessonID"]))
                                    break;
                            if (i == j)
                            {
                                courses[i] = new Courses(dr["Id"].ToString(), dr["Name"].ToString(), dr2["Day"].ToString(), dr2["StartH"].ToString(), dr2["EndH"].ToString(), dr2["ClassName"].ToString(), dr2["LessonType"].ToString(), dr2["LessonID"].ToString(), dr2["TSID"].ToString(), dr["Pre"].ToString(), student.getID());
                                i++;
                            }
                        }
                }
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0, j = 0, s = 0, t = 0;
            string temp = comboBox1.Text;

            if (!courses[comboBox1.SelectedIndex].getPassPreCourse())
                MessageBox.Show("You didnt passed the pre course of " + courses[comboBox1.SelectedIndex].getName());
            else
            {

                //check if lab choosed before lecture
                foreach (Courses cr in courses)
                {
                    if ((cr.getName() + " " + cr.getType()).Equals(temp))
                        break;
                    else i++;
                }
                if (courses[i].getType().Equals("Prac"))
                {
                    for (s = 0; s < 6; s++)
                    {
                        for (t = 0; t < 12; t++)
                        {
                            if (buttonArray[s, t].Text.Equals(courses[i].getName() + " " + "Lec"))
                                break;
                        }
                        if (t != 12) break;
                    }
                }
                //end check

                if (s == 6 && t == 12) MessageBox.Show("Error!\nCannot add course practice before lecture!");
                else
                {
                    //get the selected index by name
                    for (i = 0; i < comboBox1.Items.Count; i++)
                    {
                        if (temp.Equals(courses[i].getName() + " " + courses[i].getType()))
                            if (buttonArray[courses[i].getDay(), courses[i].getStartH()].Text == "")
                                break;
                    }
                    if (i >= comboBox1.Items.Count)
                        MessageBox.Show("ERROR!\nYou cannot add lesson at this time!");
                    else
                    {
                        int start, end, day;
                        start = courses[i].getStartH();
                        end = courses[i].getEndH();
                        day = courses[i].getDay();

                        //check if in specific day and hour we got two lessons 
                        for (j = start; j < end; j++)
                            if (!buttonArray[day, j].Text.Equals(""))
                            {
                                MessageBox.Show("ERROR!\nYou cannot add lesson at this time!");
                                break;
                            }

                        if (j == end)
                        {
                            //if we have same course in the system we will trasfer between them
                            for (s = 0; s <= 5; s++)
                            {
                                for (t = 0; t <= 11; t++)
                                {
                                    if (buttonArray[s, t].Text.Equals(temp))
                                    {
                                        buttonArray[s, t].Text = "";
                                        buttonArray[s, t].Height = 40;
                                    }
                                }
                            }

                            //add the course name on all the buttons
                            for (int k = start; k < end; k++)
                                buttonArray[day, k].Text = courses[i].getName() + " " + courses[i].getType();
                            buttonArray[day, start].Height = buttonArray[day, start].Height * (end - start) + 2 * (end - start - 1);
                            buttonArray[day, start].Text = courses[i].getName() + " " + courses[i].getType();
                            label14.Text = courses[i].getClassName();
                            label15.Text = courses[i].getType();
                            label16.Text = courses[i].getLecturer();
                            label21.Text = courses[i].getName();
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //save button
        {
            student.deleteALL();
            saveALL();
        }

        private void saveALL()
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
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    if (!(buttonArray[i,j].Equals("")) && buttonArray[i, j].Height != 40)
                    {
                        foreach (Courses cr in courses)
                        {
                            if (!(cr.getName().Equals("")) && cr.getStartH() == j && cr.getDay() == i)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO student_schedule (StudentID, LessonID) VALUES (@StudentID, @LessonID)", conn);
                                cmd.Parameters.Add("@StudentID", student.getID());
                                cmd.Parameters.Add("@LessonID", cr.getLessonID());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Data insert successfully");
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s, t;
            for (s = 0; s <= 5; s++)
            {
                for (t = 0; t <= 11; t++)
                {
                    if (buttonArray[s, t].Text.Equals(comboBox2.SelectedItem.ToString()))
                    {
                        buttonArray[s, t].Text = "";
                        buttonArray[s, t].Height = 40;
                    }
                }
            }
        }

        public void ClickedButton(Object sender,EventArgs e)
        {
            for(int i=0;i<6;i++)
            {
                for(int j=0;j<12;j++)
                {
                   if (buttonArray[i, j].Text == (sender as Button).Text)
                    {
                        for (int k = 0; k < courses.Length; k++)
                        {
                            if (courses[k].getDay() == i && courses[k].getStartH() == j && courses[k].getName()+" "+ courses[k].getType() == buttonArray[i, j].Text)
                            {
                                label14.Text = courses[k].getClassName();
                                label15.Text = courses[k].getType();
                                label16.Text = courses[k].getLecturer();
                                label21.Text = courses[k].getName();
                                break;
                            }
                        }
                    }
                }
            }   
        }

        public int checkifclassisfull(String lessonid)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT ClassName FROM Lessons WHERE LessonID='" + lessonid + "'";
 
            if (cmd2.CommandText.Length > 0)
                cmd2.ExecuteNonQuery();
            else
            {
                conn.Close();
                return 2;
            }
                
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            foreach (DataRow dr1 in dt2.Rows)
            {
                cmd3.CommandText = "SELECT Capacity FROM Classes WHERE Id='" + dr1["ClassName"].ToString() + "'";
                //MessageBox.Show("class name:" + dr1["ClassName"].ToString());
            }
            if (cmd3.CommandText.Length > 0)
                cmd3.ExecuteNonQuery();
            else
            {
                conn.Close();
                return 3;
            }
                
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);

            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "SELECT StudentID FROM student_schedule WHERE LessonID='" + lessonid + "'";
            if (cmd4.CommandText.Length > 0)
                cmd4.ExecuteNonQuery();

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(dt4);

            foreach(DataRow dr in dt4.Rows)
            {
                count++;
            }
            if ((int)dt3.Rows[0][0] >= count + 1)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }
    }
}
