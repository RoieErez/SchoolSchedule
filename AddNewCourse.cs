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
    public partial class AddNewCourse : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }
        public AddNewCourse()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddNewCourse_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select Dep_Name from Departments";
            cmd2.ExecuteNonQuery();

            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select Name from Courses";
            cmd1.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                comboBox2.Items.Add(dr["Dep_Name"].ToString());
            }

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //add new course
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Courses (Name, Points, Pre, Department, Semester) VALUES (@Name, @Points, @Pre, @Department, @Semester)", con);
            cmd.Parameters.Add("@Name", textBox1.Text);
            cmd.Parameters.Add("@Points", textBox3.Text);
            cmd.Parameters.Add("@Pre", comboBox1.GetItemText(comboBox1.SelectedItem));
            cmd.Parameters.Add("@Department", comboBox2.GetItemText(comboBox2.SelectedItem));
            cmd.Parameters.Add("@Semester", comboBox3.GetItemText(comboBox3.SelectedItem));
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Inserting Data Successfully");
                pictureBox3_Click(sender, e);
            }
            else
                MessageBox.Show("Inserting Data Failed");

            con.Close();
            AddNewCourse_Load(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)  //  exit
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
