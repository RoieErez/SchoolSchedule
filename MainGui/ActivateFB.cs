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
    public partial class ActivateFB : Form
    {
        private string FacebookID;
        public ActivateFB( String FbID)
        {
            InitializeComponent();
            FacebookID = FbID;
        }

        private void ActivateFB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Activate_Click(object sender, EventArgs e)
        {
            if (idtext.Text.Length == 0 || passtext.Text.Length == 0)
            {
                MessageBox.Show("Must enter id and password");
                return;
            }
            DataTable dt = Program.get_dt("select id from login where id='" + idtext.Text.ToString() + "' and password='" + passtext.Text.ToString() + "'");
            if (dt.Rows.Count!=0)
            {

                Program.update_sql("update Login set fb_id='" + FacebookID + "' where id='" + idtext.Text.ToString() + "'");
                MessageBox.Show("Updated - you can now Login with Facebook");
                this.Hide();
                this.Closed += (s, args) => this.Close();
                Form f = new BS_project2.Login();
                f.Show();
            }
            else
            {
                MessageBox.Show("Invalid Id and Password \ntry again");
                return;
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            Form f = new BS_project2.Login();
            f.Show();
        }

        private void ActivateFB_Load(object sender, EventArgs e)
        {
            passtext.UseSystemPasswordChar = true;
        }

        private void passtext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
