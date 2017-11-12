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

    public partial class StudentMSGSending : Form
    {
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private Student student;
        private String id;

        public Form RefToLastForm { get; set; }
        public StudentMSGSending(Student temp)
        {
            InitializeComponent();
            student = temp;
        }

        private void StudentMSGSending_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select Name from Secretary";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            conn.Close();

            label1.Text = "Hello, " + student.getName() + "Send a message please:";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            String query = "Select * from Secretary";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int index = comboBox1.SelectedIndex;
            label3.Text = (string)dt.Rows[index][2];
            id = dt.Rows[index][1].ToString();

            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  send message
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SecMes (Sender, Receiver, Body) VALUES (@Sender, @Receiver, @Body)", con);
            cmd.Parameters.Add("@Sender", student.getName());
            cmd.Parameters.Add("@Receiver", id);
            cmd.Parameters.Add("@Body", textBox1.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Inserting Data Successfully");
                con.Close();
                pictureBox1_Click(sender, e);   //  exit
            }
            else
                MessageBox.Show("Inserting Data Failed");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
