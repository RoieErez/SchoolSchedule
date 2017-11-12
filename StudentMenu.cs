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
    public partial class StudentMenu : Form
    {
        
        
        Student student;
    
        public Form RefToMainMenu { get; set; }
        public StudentMenu(Student temp)
        {
            InitializeComponent();
            student = temp;

        }
  
        private void button2_Click(object sender, EventArgs e)  //view schedule button
        {
            student_schedule HA = new student_schedule(student);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
            this.Hide();       
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + student.getName();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StudentsInfo HA = new StudentsInfo(student);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.RefToMainMenu.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void change_info_Click(object sender, EventArgs e)
        {
            StudentChangeDetails HA = new StudentChangeDetails(student);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void random_password_Click(object sender, EventArgs e)
        {
            String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(conect);
            if (!student.createrandompassword(con))
                MessageBox.Show("there was a problem entring the new password");
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //  view messages
        {
            StudentMessage HA = new StudentMessage(student);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button3_Click(object sender, EventArgs e)//change password
        {
            ChangePass cp = new ChangePass(student);
            cp.RefToLastForm = this;
            this.Visible = false;
            cp.Show();
            
        }
    }
}
