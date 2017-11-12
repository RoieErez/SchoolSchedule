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
    public partial class StudentChangeDetails : Form
    {
        Student tempstudent;
        public Form RefToLastForm { get; set; }
        private bool firstnflag=false;//for first name
        private bool lastnflag = false;//for last name
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public StudentChangeDetails(Student user)
        {
            InitializeComponent();
            tempstudent = user;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//text box for last name
        {
            if(tempstudent.Check_InPut(textBox_FirstName.Text.ToString()))
            {
                firstnflag = true;
                output_firstname.Text = "The first name you entered does not meet the requirements";
            }
            output_firstname.Text = "first name accepted";
        }

        

        private void change_the_details_Click(object sender, EventArgs e)//change button
        {
            SqlConnection con = new SqlConnection(connect);
           
            if (firstnflag==true&& lastnflag==true)
            {
               if(tempstudent.changedetailbutton(textBox_FirstName.Text.ToString(), textBox1_LastName.Text.ToString(), con))
                    MessageBox.Show("Changes made successfully");
            }
            else
                MessageBox.Show("there was a problem with one of the variables please check that you have filled both of them");              
            
        }

        private void StudentChangeDetails_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();
            this.Close();
        }
        

        private void textBox1_lastname_TextChanged(object sender, EventArgs e)
        {
            if(tempstudent.Check_InPut(textBox1_LastName.Text.ToString()))
            {
                lastnflag = true;
                output_firstname.Text = "The last name you entered does not meet the requirements";
            }
            output_firstname.Text = "last name accepted";
        }
    }
}
