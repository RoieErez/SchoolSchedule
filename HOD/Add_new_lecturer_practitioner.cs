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
    public partial class Add_new_lecturer_practitioner : Form
    {
        private CHeadOfDepartment Hod;
        public Add_new_lecturer_practitioner(CHeadOfDepartment hod)
        {
            InitializeComponent();
            Hod = hod;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);

            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();

        }

        private void Add_new_lecturer_practitioner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if(!Program.chackId(IDText.Text.ToString().ToString()))
            {
                MessageBox.Show("invalid id");
                return;
            }
        
            if (Hod.AddTeachingStaff(IDText.Text.ToString(), NameText.Text.ToString(), lecturer, practioner))
                MessageBox.Show("Add succesfully");
        }

        private void Add_new_lecturer_practitioner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Add_new_lecturer_practitioner_Load(object sender, EventArgs e)
        {

        }
    }
}
