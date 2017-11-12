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
    public partial class AddNewDepartment : Form
    {
        public Form RefToLastForm { get; set; }
        public AddNewDepartment()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddNewDepartment_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Departments (Dep_Name) VALUES (@Dep_Name)", con);
            cmd.Parameters.Add("@Dep_Name", textBox1.Text);
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Inserting Data Successfully");
            else
                MessageBox.Show("Inserting Data Failed");

            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
