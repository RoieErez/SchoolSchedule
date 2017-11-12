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
using BS_project2.Classes;

namespace BS_project2
{
    public partial class transferStudent : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }

        public transferStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void transferStudent_Load(object sender, EventArgs e)
        {
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
                comboBox1.Items.Add(dr["Dep_Name"].ToString());
            }

            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student;
            string ID = textBox1.Text;
            SqlConnection con = new SqlConnection(connect);
            string query = "Select * from Students where ID = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            query = "Select * from Login where Id = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);


            if (dt.Rows.Count == 0) MessageBox.Show("No ID exist in the collage");
            else
            {
                student = new Student(dt.Rows[0][1].ToString(), dt.Rows[0][0].ToString(), "0", dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), (bool)dt.Rows[0][4]);
                student.deleteALL();
                dt.Rows[0].BeginEdit();
                dt1.Rows[0].BeginEdit();
                dt.Rows[0][2] = comboBox1.Text;
                dt1.Rows[0][4] = comboBox1.Text;
                dt.Rows[0].EndEdit();
                dt1.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(sda);
                SqlCommandBuilder cb1 = new SqlCommandBuilder(sda1);
                sda.Update(dt);
                sda1.Update(dt1);
                MessageBox.Show("The student was successfully assigned to the department " + comboBox1.Text);
                button1_Click(sender, e);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
