using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BS_project2.Classes;

namespace BS_project2
{
    public partial class SecretaryBuildSchedule : Form
    {
        String connect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Form RefToLastForm { get; set; }

        public SecretaryBuildSchedule()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  continue
        {
            String ID = textBox1.Text;
            SqlConnection con = new SqlConnection(connect);
            String query = "Select * from Students where ID = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0) MessageBox.Show("No ID exist in the collage");
            else
            {
                Student student = new Student(dt.Rows[0][1].ToString(), dt.Rows[0][0].ToString(), "0", dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), (bool)dt.Rows[0][4]);
                student_schedule HA = new student_schedule(student);
                HA.RefToLastForm = this;
                this.Visible = false;
                HA.Show();
            }
        }
    }
}
