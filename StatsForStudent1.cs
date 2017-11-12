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
  
    public partial class StatsForStudent1 : Form
    {
        public StatsForStudent1()
        {
            InitializeComponent();
        }

        public Form RefToLastForm { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool IdFlag = false;

            String connect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connect);
            String query = "Select * from Login"; //where id = '" + textBox1.Text.Trim() + "'"; //and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //check if the imput id appears in database
            foreach (DataRow dr in dt.Rows)
            {
                if (textBox1.Text == dr["id"].ToString())
                {
                    IdFlag = true;
                    break;
                }

            }

            if (IdFlag)
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("select * from Students where ID = '" + textBox1.Text + "'", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);

                Student student = new Student(dt2.Rows[0][1].ToString(), dt2.Rows[0][0].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString(), dt2.Rows[0][3].ToString(), (bool)dt2.Rows[0][4]);
                StatsForStudent2 s = new StatsForStudent2(student);
                s.RefToLastForm = this.RefToLastForm;
                s.Show();
                this.Close();

            }
            else
                MessageBox.Show(this, "Please enter an ID/correct Id");



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
