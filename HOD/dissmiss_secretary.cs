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
    public partial class dissmiss_secretary : Form
    {
        private CHeadOfDepartment Hod;
        public dissmiss_secretary(CHeadOfDepartment obj)
        {
            InitializeComponent();
            Hod = obj;
        }
        public dissmiss_secretary()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();


        }

        private void dissmiss_secretary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        { /*dismiss sercretary and remove from data base*/
            if (idText.Text.Count() != 0)
            {

                if (Hod.dismissSecretary(idText.Text.ToString()))
                    MessageBox.Show("deleted succesfully");
                else
                    MessageBox.Show("Id not found");
            }
            else
                MessageBox.Show("Must enter id");
        }

        private void dissmiss_secretary_Load(object sender, EventArgs e)
        {

        }
    }
}
