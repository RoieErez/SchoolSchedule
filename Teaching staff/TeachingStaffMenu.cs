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
    public partial class TeachingStaffMenu : Form
    {
        private CTeachingStaff TS;
        public TeachingStaffMenu()
        {
            InitializeComponent();
        }
        public TeachingStaffMenu(CTeachingStaff ts):this()
        {
            TS = ts;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void TeachingStaffMenu_Load(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
        {
            
            if (TS.Constraints.Length ==0)
            {
                TS.Constraints = richTextBox1.Text.ToString();
                if(TS.addConstraintsToDB())
                    MessageBox.Show("Success");
                else
                    MessageBox.Show("Failed to update DB");

            }
                
            else
                MessageBox.Show("allready sent constraints");


        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            TS_MySchedule p = new TS_MySchedule(TS);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            p.Show();
        }

        private void TeachingStaffMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            CUser.LogOut();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Change_pass p = new Change_pass(TS);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            p.Show();
        }
    }
}


