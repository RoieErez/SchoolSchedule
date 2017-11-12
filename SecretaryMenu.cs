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
    public partial class SecretaryMenu : Form
    {
        private Secretary secretary;
        public Form RefToMainMenu { get; set; }
        public SecretaryMenu(Secretary temp)
        {
            InitializeComponent();
            secretary = temp;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.RefToMainMenu.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatsForStudent1 S = new StatsForStudent1();
            S.RefToLastForm = this;
            S.Show();
            this.Visible = false;
        }

        private void SecreteryMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + secretary.getName();
        }

        private void button4_Click(object sender, EventArgs e)  //  View private messages
        {
            SecretaryMessage HA = new SecretaryMessage(secretary);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass(secretary);
            cp.RefToLastForm = this;
            this.Visible = false;
            cp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SecretaryBuildSchedule HA = new SecretaryBuildSchedule();
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }
    }
}
