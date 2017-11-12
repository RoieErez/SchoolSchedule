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
using System.Data.Sql;
using BS_project2.Classes;

namespace BS_project2
{
    public partial class StudentReplyMSG : Form
    {
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private Student student;
        private Secretary secretary;
        public Form RefToLastForm { get; set; }
        public StudentReplyMSG(Student temp1, string temp2)
        {
            InitializeComponent();
            student = temp1;

            SqlConnection con = new SqlConnection(constring);
            String query = "Select * from Secretary where Name = '" + temp2+"'" ;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            
            secretary = new Secretary(dt.Rows[0][1].ToString(), dt.Rows[0][0].ToString(), "empty", dt.Rows[0][2].ToString());
            con.Close();
        }

        private void StudentReplyMSG_Load(object sender, EventArgs e)
        {
            label3.Text = "Name: "+secretary.getName() +", Department: "+secretary.getDepartment() ;
            label1.Text = "Hello, " + student.getName() + "Send a message please:";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SecMes (Sender, Receiver, Body) VALUES (@Sender, @Receiver, @Body)", con);
            cmd.Parameters.Add("@Sender", student.getName());
            cmd.Parameters.Add("@Receiver", secretary.getID());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
