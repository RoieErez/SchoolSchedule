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
    public partial class StudentsInfo : Form
    {
        Student student;
        public Form RefToLastForm { get; set; }
        public StudentsInfo(Student tmp)
        {
            InitializeComponent();
            student = tmp;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = student.getName();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = student.getDep();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = student.getSemester().ToString();
        }

        private void StudentsInfo_Load(object sender, EventArgs e)
        {
            label5.Text = student.getName();
            label6.Text = student.getDep();
            label7.Text = student.getSemester().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();
            this.Close();
        }
    }
}
