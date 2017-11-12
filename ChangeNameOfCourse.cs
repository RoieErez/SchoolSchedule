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
    public partial class ChangeNameOfCourse : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }
        public ChangeNameOfCourse()
        {
            InitializeComponent();
        }

        private void Change_Name_Click(object sender, EventArgs e)//change name button
        {
            SqlConnection con = new SqlConnection(connect);
            string query = "Select * from Courses where Name = '" + comboBox2_selectcourse.Text + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dt.Rows[0].BeginEdit();
            dt.Rows[0][1] = textBox1_newcoursename.Text;
            dt.Rows[0].EndEdit();
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("The course was successfully changed to " + textBox1_newcoursename.Text);
        }

        private void ChangeNameOfCourse_Load(object sender, EventArgs e)//enters data to comboboxs in the furm
        {
            comboBox1_selectdepartment.Items.Clear();
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select Dep_Name from Departments";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                comboBox1_selectdepartment.Items.Add(dr["Dep_Name"].ToString());
            }
            conn.Close();
        }

        private void textBox1_newcoursename_TextChanged(object sender, EventArgs e)
        {

        }
        public void Initialization_Of_Combobox2()//shows in combobox2 Only the courses related to the department
        {
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            comboBox2_selectcourse.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT Name FROM Courses WHERE Department='" + comboBox1_selectdepartment.SelectedItem.ToString() + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox2_selectcourse.Items.Add(dr["Name"].ToString());
            }
            conn.Close();
        }

        private void comboBox1_selectdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialization_Of_Combobox2();
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();
            this.Close();
        }
    }
}
