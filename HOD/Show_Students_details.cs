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
    public partial class Show_Students_details : Form
    {
        private CHeadOfDepartment Hod;
        public Show_Students_details()
        {
            InitializeComponent();
        }
        public Show_Students_details(CHeadOfDepartment hod)
        {
            InitializeComponent();
            Hod = hod;
        }

        private void Show_Students_details_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if(!(Hod.showStudentsDetails(comboBox1.GetItemText(comboBox1.SelectedItem), listView1)))
                 MessageBox.Show("No Students at the semester are you selected.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Show_Students_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
