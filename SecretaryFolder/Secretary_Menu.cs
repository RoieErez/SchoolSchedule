using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2.SecretaryFolder
{
    public partial class Secretary_Menu : Form
    {
        private CSecretary sec;
        public Secretary_Menu()
        {
            InitializeComponent();
        }
        public Secretary_Menu(CSecretary s)
        {
            InitializeComponent();
            sec = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecretaryFolder.Secretary_BuildSchdule f = new Secretary_BuildSchdule(sec);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f.Show();
        }

  

  
        private void Secretary_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            CUser.LogOut();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Change_pass p = new Change_pass(sec);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            p.Show();

        }

        private void Secretary_Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    
    }
}
