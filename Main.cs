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
using BS_project2.Classes;

namespace BS_project2
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 12;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 12;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String connect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connect);
            String query = "Select * from Login where id = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][3].Equals("Student"))
                {
                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from Students where ID = '"+dt.Rows[0][0]+"'", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    Student student = new Student(dt2.Rows[0][1].ToString(), dt2.Rows[0][0].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString(), dt2.Rows[0][3].ToString(), (bool)dt2.Rows[0][4]);

                    //first entrance of the student
                    //need to change his initial password
                    if (dt.Rows[0][0].Equals(dt.Rows[0][2]))//initial password equals ID
                    {
                        InitPassChange FM = new InitPassChange();
                        FM.RefToLastForm = this;
                        this.Visible = false;
                        FM.Show();
                    }
                    //not the first entrence of the student
                    else
                    {
                        if ( !student.getStatus() )
                        { 
                            MessageBox.Show("Your student's status is NOT active,\nplease go to 'Student's Accounts'");
                        }
                        else
                        {
                            StudentMenu HA = new StudentMenu(student);
                            HA.RefToMainMenu = this;
                            this.Visible = false;
                            HA.Show();
                        }
                    }
                }
                else if (dt.Rows[0][3].Equals("Secretary"))
                {
                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from Secretary;", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    Secretary secretery = new Secretary(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString());
                    SecretaryMenu HA = new SecretaryMenu(secretery);
                    HA.RefToMainMenu = this;
                    this.Visible = false;
                    HA.Show();
                }
                else if (dt.Rows[0][3].Equals("President"))
                {
                    President president = new President(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    PresidentMenu HA = new PresidentMenu(president);
                    HA.RefToMainMenu = this;
                    this.Visible = false;
                    HA.Show();
                }
                else if (dt.Rows[0][3].Equals("HK"))
                {
                    HouseKeeper houseKeeper = new HouseKeeper(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    HouseKeeperMenu HA = new HouseKeeperMenu(houseKeeper);
                    HA.RefToMainMenu = this;
                    this.Visible = false;
                    HA.Show();
                }
                else
                {
                    MessageBox.Show("Unknown Permission");
                }
            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
            con.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
