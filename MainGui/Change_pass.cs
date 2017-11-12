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
    public partial class Change_pass : Form
    {
        private CUser u;
        
        public Change_pass(CUser obj)
        {
            
            InitializeComponent();
            u = obj;
            
        }

        private void Change_pass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                this.Hide();
                this.Closed += (s, args) => this.Close();
                if(u.ChangePassword(textBox1.Text))
                    MessageBox.Show("Success");
                u.Password = textBox1.Text;
                Login l = new Login();
                l.Show();


            }
            else
                MessageBox.Show("try again - not matched");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt= Program.get_dt("SELECT Permission FROM Login WHERE Id='" + u.Id+"'");
            if (dt.Rows[0][0].Equals("HOD"))
            {

                this.Hide();
                HeadOfDepart_Main HA = new HeadOfDepart_Main(((CHeadOfDepartment)u));
                this.Closed += (s, args) => this.Close();
                HA.Show();

            }
            if (dt.Rows[0][0].Equals("TS"))
            {
                this.Hide();
                TeachingStaffMenu Ts = new TeachingStaffMenu(((CTeachingStaff)u));

                this.Closed += (s, args) => this.Close();
                Ts.Show();

            }
            if (dt.Rows[0][0].Equals("SEC"))
            {

                this.Hide();
               
                SecretaryFolder.Secretary_Menu Sec = new SecretaryFolder.Secretary_Menu(((CSecretary)u));
                this.Closed += (s, args) => this.Close();
                Sec.Show();
               
            }
            if (dt.Rows[0][0].Equals("ADS"))
            {
                this.Hide();
                Administration.Administration_main Es = new Administration.Administration_main(((CAdministration)u));
                this.Closed += (s, args) => this.Close();
                Es.Show();

            }

        }

        private void Change_pass_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
