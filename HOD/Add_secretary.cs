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
    public partial class Add_secretary : Form
    {
        private CHeadOfDepartment Hod;
        public Add_secretary(CHeadOfDepartment hod)
        {
            InitializeComponent();
            Hod = hod;
        }
        public Add_secretary()
        {
            InitializeComponent();
        }

        private void Add_secretary_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HeadOfDepart_Main form = new HeadOfDepart_Main(Hod);
            this.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void Add_secretary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void enter_button_Click(object sender, EventArgs e)
        {/*add sercretary to data base*/


            if (!Program.chackId(IDText.Text.ToString().ToString()))
            {
                MessageBox.Show("invalid id");
                return;
            }
            if (Hod.addSecretary(IDText.Text.ToString(), NameText.Text.ToString()))
                 MessageBox.Show("Success");
            else
                MessageBox.Show("You could not add a secretary.");
        }
    }
}
