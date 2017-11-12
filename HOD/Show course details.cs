using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2.HOD
{
    public partial class Show_course_details : Form
    {
        private CHeadOfDepartment HOD;
        public Show_course_details()
        {
            InitializeComponent();
        }

        public Show_course_details(CHeadOfDepartment hod)
        {
            InitializeComponent();
            HOD = hod;
        }

        private void Show_course_details_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            listView1.Items.Clear();
            /*if NOT*/
            if (!(HOD.showCourseDetails(comboBox1.GetItemText(comboBox1.SelectedItem),listView1)))
                /*not have courses in semester*/
                MessageBox.Show("No courses at the semester are you selected.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(HOD);

            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void Show_course_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
