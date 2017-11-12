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
    public partial class HOD_Assign_lecturer_and_pract : Form
    {
        private CHeadOfDepartment Hod;
      
        public HOD_Assign_lecturer_and_pract(CHeadOfDepartment obj)
        {
            InitializeComponent();
            Hod = obj;
        }
        public HOD_Assign_lecturer_and_pract()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HOD_Assign_lecturer_and_pract_Load(object sender, EventArgs e)
        {
            /*fill comboboxs with lecturers and courses*/
            DataTable dt1 = Program.get_dt("SELECT f_name,id FROM Login where department='" + Hod.Department + "' and permission='TS'");
            DataTable dt2 = Program.get_dt("SELECT id FROM Teaching_staff where type= 'Practioner'");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    if (dt1.Rows[i][1].ToString() == dt2.Rows[j][0].ToString())
                    {
                        comboBox1.Items.Add(dt1.Rows[i][0].ToString());
                      
                    }
                }
            }
            DataTable dt3 = Program.get_dt("SELECT name,id FROM Courses where department='" + Hod.Department + "'");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt3.Rows[i][0].ToString());
       
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void HOD_Assign_lecturer_and_pract_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose practitioner");
                return;
            }
            if(comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Must choose course");
                return;
            }
            DataTable dt1 = Program.get_dt("SELECT id FROM Login where department='" + Hod.Department + "' and permission='TS' and f_name='" + comboBox1.SelectedItem.ToString() + "'");
            DataTable dt2 = Program.get_dt("SELECT id FROM courses where name='" + comboBox2.SelectedItem.ToString() + "'");
            if(Hod.AddLecturer_PracAssignment(dt2.Rows[0][0].ToString(), dt1.Rows[0][0].ToString()))
                MessageBox.Show("Added successfully");
            else
                MessageBox.Show("assignment allready exist");

        }
    }
}
