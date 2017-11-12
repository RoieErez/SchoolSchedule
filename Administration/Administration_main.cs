using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BS_project2.Administration
{
    public partial class Administration_main : Form
    {
        private CAdministration ADS;
        public Administration_main()
        {
            InitializeComponent();
        }
        public Administration_main(CAdministration ads) :this()
        {
            ADS = ads;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Closed += (s, args) => this.Close();
            CUser.LogOut();
        }

        private void Exams_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change_pass p = new Change_pass(ADS);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            p.Show();
        }

        private void Exams_main_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Information about class*/
            this.Hide();
            Administration.Admin_Information_about_classes F1 = new Admin_Information_about_classes(ADS);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Edit class*/
            this.Hide();
            Administration.Admin_Edit_class F1 = new Admin_Edit_class(ADS);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*Add class*/
            this.Hide();
            Administration.Admin_Add_class F1 = new Admin_Add_class(ADS);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*Remove class*/
            this.Hide();
            Administration.Admin_Remove_class F1 = new Admin_Remove_class(ADS);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*Add student*/
            this.Hide();
            Administration.Admin_Add_student F1 = new Admin_Add_student(ADS);
            this.Closed += (s, args) => this.Close();
            F1.Show();
        }
    }
}
