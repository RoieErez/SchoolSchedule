using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BS_project2
{
    public partial class InitPassChange : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }
        public InitPassChange()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)//re entered correctly the new password
            {
                SqlConnection con = new SqlConnection(connect);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Login SET Password='" + textBox1.Text + "' WHERE (Id='" + textBox3.Text + "')", con);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Updated Data Successfully");
                    RefToLastForm.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Update Failed");

                con.Close();
            }
            else
            {
                textBox2.Clear();
                MessageBox.Show("Re-entered incorrect password!");
                
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitPassChange_Load(object sender, EventArgs e)
        {

        }
    }
}
///need to add an update to the students table after registred student maje his initial entrance and updates initial password
