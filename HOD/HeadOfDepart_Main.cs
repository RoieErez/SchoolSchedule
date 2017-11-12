using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2
{
    public partial class HeadOfDepart_Main : Form
    {
        private CHeadOfDepartment Hod;
        public HeadOfDepart_Main(CHeadOfDepartment hod) :this()
        {
            Hod = hod;
        }
        public HeadOfDepart_Main()
        {
            InitializeComponent();
        }

        private void HeadOfDepart_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HOD.HOD_Assign_lecturer f1 = new HOD.HOD_Assign_lecturer(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();


        }

        private void HeadOfDepart_Main_Load(object sender, EventArgs e)
        {
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOD.HOD_Assign_lecturer_and_pract F1 = new HOD.HOD_Assign_lecturer_and_pract(Hod);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HOD.Dismiss_lecturer_practitioner f1 = new HOD.Dismiss_lecturer_practitioner(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Change_pass p = new Change_pass(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            CUser.LogOut();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOD.Add_new_lecturer_practitioner F1 = new HOD.Add_new_lecturer_practitioner(Hod);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.Add_secretary form = new HOD.Add_secretary(Hod);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.dissmiss_secretary form = new HOD.dissmiss_secretary(Hod);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.show_TS f = new HOD.show_TS(Hod);
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.Show_course_details f = new HOD.Show_course_details(Hod);
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.Show_Students_details f = new HOD.Show_Students_details(Hod);
            f.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HOD.Show_Ts_Assignment f = new HOD.Show_Ts_Assignment(Hod);
            f.Show();
        }
    }
}
