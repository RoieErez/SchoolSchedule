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

namespace BS_project2
{
    public partial class change_greatnes : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }
        private Boolean flag = false;
        public change_greatnes()
        {
            InitializeComponent();
        }

        private void change_greatnes_Load(object sender, EventArgs e)//enters data to comboboxs in the furm
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

        private void textBox1_newGreatnes_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1_newGreatnes.Text, "[ ^ 1-9]"))
                check_input.Text = "The input which is required should be one digit between 1-9 only";
            else
            {
                check_input.Text = "Right input";
                flag = true;
            }
        }

        private void button1_changeGreatnes_Click(object sender, EventArgs e)//change greatnes button
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            if (flag == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Courses SET [Points] ='" + textBox1_newGreatnes.Text.ToString() + "'" + " WHERE [Department] = '" + comboBox1_selectdepartment.SelectedItem.ToString() + "'" + " AND [Name] ='" + comboBox2_selectcourse.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("course greatnes changed Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }
            }
            else
                MessageBox.Show("The input that you entered in (enter new greatnes) isnt good please enter a correct input for the process to succeed");
            con.Close();
        }

        private void comboBox2_selectcourse_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
