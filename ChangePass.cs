using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS_project2.Classes;
using System.Data.SqlClient;

namespace BS_project2
{
    public partial class ChangePass : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }
        User thisPerson;
        int correctFlag = 0, lenghtFlag = 0, reEnterFlag = 0;
        public ChangePass(User obj)
        {
            thisPerson = obj;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (thisPerson.getPass() == textBox1.Text.ToString())
            {
                label5.Visible = true;
                label5.Text = "correct password, continue...";
                correctFlag = 1;
            }
            else
            {
                label5.Visible = true;
                label5.Text = "Incorrect password, please correct the field.";
                correctFlag = 0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 6;
            if ((textBox2.Text.ToString() == textBox3.Text.ToString())&& correctFlag==1 && lenghtFlag==1)
            {
                reEnterFlag = 1;
                label7.Visible = true;
                label7.Text = "Confirm your new password below. :)";
            }
            else
            {
                reEnterFlag = 0;
                label7.Visible = true;
                label7.Text = "Somthing is wrong...";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)  //  apply new password
        {
            if (thisPerson.changePass(textBox1.Text, textBox2.Text, textBox3.Text))
                MessageBox.Show("Password was updated Successfully");// if true
            else
                MessageBox.Show("Error!\nNo change was applyed");//  if false
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 6;
            if (textBox3.Text.Length > 6)
            {
                label6.Visible = true;
                label6.Text = "Password must contain Maximum 6 characters.";
                lenghtFlag = 0;
            }
            else if (textBox3.Text.ToString() == textBox1.Text.ToString())
            {
                label6.Visible = true;
                label6.Text = "Yor new password must be different from your old password!";
                lenghtFlag = 0;
            }
            else 
            {
                label6.Visible = true;
                label6.Text = "OK...";
                lenghtFlag = 1;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
