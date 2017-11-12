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
    public partial class SecretaryMSGSending : Form
    {
        private Secretary secretary;
        private int index;
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }

        public SecretaryMSGSending(Secretary temp)
        {
            InitializeComponent();
            secretary = temp;
        }

        private void SecretaryMSGSending_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select Name from Students";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            conn.Close();
            label4.Text = "Hello, " + secretary.getName() + " Send a message please:";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            String query = "Select * from Students";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            index = comboBox1.SelectedIndex;
            if (index == 0) label2.Text = "All";
            else label2.Text = (string)dt.Rows[index-1][2];
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  send message
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if (index == 0) //  selected all students
            {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select Name from Students";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO StudentMes (Sender, Receiver, Body) VALUES (@Sender, @Receiver, @Body)", con);
                    cmd.Parameters.Add("@Sender", secretary.getName());
                    cmd.Parameters.Add("@Receiver", dr["ID"].ToString());
                    cmd.Parameters.Add("@Body", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            else                        //  selected 1 student
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentMes (Sender, Receiver, Body) VALUES (@Sender, @Receiver, @Body)", con);
                cmd.Parameters.Add("@Sender", secretary.getName());
                cmd.Parameters.Add("@Receiver", comboBox1.GetItemText(comboBox1.SelectedItem));
                cmd.Parameters.Add("@Body", textBox1.Text);
                cmd.ExecuteNonQuery();
            }
                MessageBox.Show("Inserting Data Successfully");
                con.Close();
                pictureBox1_Click(sender, e);   //  exit
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
