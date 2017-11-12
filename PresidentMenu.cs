using BS_project2.Classes;
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

namespace BS_project2
{
    public partial class PresidentMenu : Form
    {
        President president;
        public Form RefToMainMenu { get; set; }

        public PresidentMenu(President temp)
        {
            InitializeComponent();
            president = temp;
        }

        private void button1_Click(object sender, EventArgs e)  //  View list of employees
        {
            viewListOfEmployees HA = new viewListOfEmployees();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button2_Click(object sender, EventArgs e)  //  Add new department button
        {
            AddNewDepartment HA = new AddNewDepartment();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button3_Click(object sender, EventArgs e)  //  View list of departments
        {
            ViewListOfDepartments HA = new ViewListOfDepartments();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button5_Click(object sender, EventArgs e)  //  Add new course
        {
            AddNewCourse HA = new AddNewCourse();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void President_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + president.getName();
        }

        private void button14_Click(object sender, EventArgs e)     //remove course button
        {
            RemoveCourse HA = new RemoveCourse();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.RefToMainMenu.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void change_course_name_Click(object sender, EventArgs e)
        {
            ChangeNameOfCourse HA = new ChangeNameOfCourse();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button4_Click(object sender, EventArgs e)  //  view list of courses
        {
            viewListOfCourses HA = new viewListOfCourses();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            change_greatnes HA = new change_greatnes();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass(president);
            cp.RefToLastForm = this;
            this.Visible = false;
            cp.Show();
        }

        private void button8_Click(object sender, EventArgs e)  //  trnsfer student department
        {
            transferStudent ts = new transferStudent();
            ts.RefToLastForm = this;
            this.Visible = false;
            ts.Show();
        }
    }
}
