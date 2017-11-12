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
    public partial class RemoveCourse : Form
    {
        public Form RefToLastForm { get; set; }
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public RemoveCourse()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)     //  shows list of all courses 
        {

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RemoveCourse_Load_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select Name from Courses";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void pictureBox3_Click(object sender, EventArgs e)  //  removes course button
        {
            if (MessageBox.Show("Are you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Courses WHERE Name = @Name", conn);
                cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                pictureBox1_Click(sender, e);
            }
        }
    }
}
