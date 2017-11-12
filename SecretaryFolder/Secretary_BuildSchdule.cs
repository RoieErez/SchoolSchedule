using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2.SecretaryFolder
{
    public partial class Secretary_BuildSchdule : Form
    {
        private CSecretary Sec;
        private DataTable t,courses;
        private string day="Sunday";
        public Secretary_BuildSchdule()
        {
            InitializeComponent();
            
        }

        public Secretary_BuildSchdule(CSecretary sec):this()
        {
            
            Sec = sec;
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecretaryFolder.Secretary_Menu sm = new Secretary_Menu(Sec);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            sm.Show();
        }

        private void Secretary_BuildSchdule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //lecture choose
        {
            
        }

 

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex!=-1)
                detailsbox.Text = "Number of students in course:" + courses.Rows[comboBox3.SelectedIndex][1].ToString()+":\n"+ Sec.getNumOfStudents(courses.Rows[comboBox3.SelectedIndex][2].ToString());
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.SelectedItem = null;
            comboBox7.Items.Clear();
            if (comboBox3.SelectedIndex < 0)
                return;
            DataTable t = Program.get_dt("select LessonType from lessons where courseid='" + courses.Rows[comboBox3.SelectedIndex][0].ToString() + "'");
            int practition = 0, lecture = 0;
            for (int i=0;i<t.Rows.Count;i++)
            {
                if (t.Rows[i][0].Equals("Prac"))
                    practition++;
                else
                    lecture++;


            }
            int num = Sec.getNumOfStudents(courses.Rows[comboBox3.SelectedIndex][2].ToString());
            int c;
            int p = 0;
            if (num % 250 != 0)
            {
                p = (num / 25) + 1;
            }
            else
                p = num / 25;

            if (num % 50 != 0)
            {
                c = (num / 50) + 1;
            }
            else
                c = num / 50;

            for (int i = 0; i < c-lecture; i++)
                comboBox7.Items.Add("Lec");
               
            for (int i = 0; i <p-practition; i++)
                comboBox7.Items.Add("Prac");
               
            




            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex!=-1)
            {
                day = "Sunday";
                button5.Text = "Add to " + day;
                listView1.Items.Clear();
                setColor(1);
                if (comboBox1.SelectedIndex != -1)
                {
                    List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                    for (int i = 0; i < list.Count; i++)
                        listView1.Items.Add(list[i]);

                }
            }
            comboBox3.SelectedItem = null;
            comboBox3.Items.Clear();
            
            courses = Sec.getCoursesBySem(comboBox1.SelectedItem.ToString());
            for (int i = 0; i < courses.Rows.Count; i++)
                comboBox3.Items.Add(courses.Rows[i][1]);
        }

      
        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

      

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose semester");
                return;
            }
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose course");
                return;
            }
            if (comboBox7.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose type");
                return;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose Teaching staff");
                return;
            }
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose start hour");
                return;
            }
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose end hour");
                return;
            }
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose class");
                return;
            }


            ListViewItem item = new ListViewItem(comboBox4.SelectedItem.ToString());
            item.SubItems.Add(comboBox5.SelectedItem.ToString());
            item.SubItems.Add(comboBox3.SelectedItem.ToString()+"-"+comboBox7.SelectedItem.ToString());
            item.SubItems.Add(comboBox2.SelectedItem.ToString());
            item.SubItems.Add(comboBox6.SelectedItem.ToString());

            string tsid=null,courseid=null;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                if (comboBox2.SelectedItem.ToString().Equals(t.Rows[i][0].ToString()))
                {
                    tsid = t.Rows[i][3].ToString();
                }
            }
            for (int i = 0; i < courses.Rows.Count; i++)
            {
                if (comboBox3.SelectedItem.ToString().Equals(courses.Rows[i][1].ToString()))
                {
                    courseid = courses.Rows[i][0].ToString();
                }
            }
            if (Sec.AddLesson(comboBox7.SelectedItem.ToString(), comboBox1.SelectedItem.ToString()
                , courseid, day, comboBox4.SelectedItem.ToString()
                , comboBox5.SelectedItem.ToString(), tsid, comboBox6.SelectedItem.ToString()))
            {
                listView1.Items.Add(item);
                comboBox7.Items.RemoveAt(comboBox7.SelectedIndex);
                MessageBox.Show("Added successfully");
            }


            comboBox6.SelectedIndex = -1;

            comboBox6.Items.Clear();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            day = "Sunday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(1);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);
                
            }
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            day = "Monday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(2);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            day = "Tuesday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(3);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            day = "Wednesday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(4);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            day = "Thursday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(5);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            day = "Friday";
            button5.Text = "Add to " + day;
            listView1.Items.Clear();
            setColor(6);
            if (comboBox1.SelectedIndex != -1)
            {
                List<ListViewItem> list = Sec.getLessonsByDay(day, comboBox1.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                    listView1.Items.Add(list[i]);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                for(int i=0;i<t.Rows.Count;i++)
                {
                    if(comboBox2.SelectedItem.ToString().Equals(t.Rows[i][0].ToString()))
                    {
                        if (t.Rows[i][1].ToString().Length == 0)
                             detailsbox.Text = "No constraints";
                        else
                            detailsbox.Text = t.Rows[i][1].ToString();
                    }

                }


            
            }
        }

        private void Secretary_BuildSchdule_Load_1(object sender, EventArgs e)
        {

            t = Sec.SeeTSconstraints();
            button5.Text = "Add to " + day;
         
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = null;
            comboBox2.Items.Clear();
            if (comboBox3.SelectedIndex != -1 && comboBox7.SelectedIndex!=-1)
            {
                
                List<string> TS = Sec.getTsByCourseAssignment(courses.Rows[comboBox3.SelectedIndex][0].ToString());
                foreach (string x in TS)
                {
                    for(int i=0;i<t.Rows.Count;i++)
                    {
                        if(x == t.Rows[i][0].ToString())
                        {
                            if(comboBox7.SelectedItem.ToString().Contains("Prac") && t.Rows[i][2].ToString()== "Practioner")
                                comboBox2.Items.Add(x);
                            else if (comboBox7.SelectedItem.ToString().Contains("Lec") && t.Rows[i][2].ToString() == "Lecturer")
                                comboBox2.Items.Add(x);
                        }
                       
                    }
                       
                }

                  
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item have been selected");
                return;
            }
            DataTable t = Program.get_dt("select lessonId from student_schedule where lessonId= '" + listView1.SelectedItems[0].SubItems[5].Text + "'");

            if (t.Rows.Count >0)
            {
                MessageBox.Show("cannot delete this lesson,there are students registered for a lesson");

                return;

            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete item?", "Delete lesson", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                

                


                if (Sec.deleteLesson(listView1.SelectedItems[0].SubItems[5].Text))
                    MessageBox.Show("Deleted successfully");
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
           
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox6.SelectedIndex = -1;

            comboBox6.Items.Clear();
            if (comboBox4.SelectedIndex == -1 || comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Must enter hours before");
                return;
            }
            string start = comboBox4.SelectedItem.ToString();
            string end = comboBox5.SelectedItem.ToString();
            string start2, end2, ClassName, ClassName2,day2;
            int capacity;
            bool flag = true;
            DataTable Lessons = Program.get_dt("select StartH,EndH,ClassName,day from lessons");
            DataTable Classes = Program.get_dt("select id,capacity from classes");
            if (comboBox7.SelectedItem.ToString().Equals("Prac"))
                capacity = 25;
            else
                capacity = 50;
            for (int i = 0; i < Classes.Rows.Count; i++)// move over classes
            {
               
                if (capacity > Int32.Parse(Classes.Rows[i][1].ToString()))
                    continue;
                ClassName = Classes.Rows[i][0].ToString();
                for (int j = 0; j < Lessons.Rows.Count; j++)//move over lessons
                {
                    start2 = Lessons.Rows[j][0].ToString();//start time
                    end2 = Lessons.Rows[j][1].ToString();//end time
                    ClassName2 = Lessons.Rows[j][2].ToString();//class name
                    day2 = Lessons.Rows[j][3].ToString();
                    if (!Sec.notSameTime(start, start2, end, end2) && ClassName2.Equals(ClassName) && day.Equals(day2))
                        flag = false;



                }
                if (flag)//if class is free at this time
                    comboBox6.Items.Add(ClassName);
                flag = true;

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.SelectedIndex = -1;

            comboBox6.Items.Clear();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.SelectedIndex = -1;

            comboBox6.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex!=-1)
                detailsbox.Text = "Id: " + courses.Rows[comboBox3.SelectedIndex][0].ToString() + "\nName: " + courses.Rows[comboBox3.SelectedIndex][1].ToString() + "\nSemester: " + courses.Rows[comboBox3.SelectedIndex][2].ToString();
        }
        private void setColor(int day)
        {
            sundayP.BackColor = Color.Empty;
            mondayP.BackColor = Color.Empty;
            tuesdayP.BackColor = Color.Empty;
            ThurP.BackColor = Color.Empty;
            fridayP.BackColor = Color.Empty;
            wendsP.BackColor = Color.Empty;
            if(day==1)
                sundayP.BackColor = Color.Black;
            if (day == 2)
                mondayP.BackColor = Color.Black;
            if (day == 3)
               tuesdayP.BackColor = Color.Black;
            if (day == 4)
                wendsP.BackColor = Color.Black;
            if (day == 5)
                ThurP.BackColor = Color.Black;
            if (day ==6)
                fridayP.BackColor = Color.Black;

        }
    }
}
