using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2.Administration
{
    public partial class Admin_Add_student : Form
    {
        CAdministration ADS;
        public Admin_Add_student()
        {
            InitializeComponent();
        }
        public Admin_Add_student(CAdministration ads)
        {
            InitializeComponent();
            ADS = ads;
        }

        private void Admin_Add_student_Load(object sender, EventArgs e)
        {

        }

        private void Admin_Add_student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administration_main f1 = new Administration_main(ADS);

            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!Program.chackId(textBox1.Text.ToString().ToString()))
            {
                MessageBox.Show("invalid id");
                return;
            }


            string s = null; 
            if (comboBox1.SelectedItem != null)
                s = comboBox1.SelectedItem.ToString();
            if (ADS.addStudent(textBox1.Text.ToString(), textBox2.Text.ToString(), comboBox3.GetItemText(comboBox3.SelectedItem),s ))
                MessageBox.Show("Add student success!");
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
