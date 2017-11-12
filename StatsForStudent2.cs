using BS_project2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2
{
    public partial class StatsForStudent2 : Form
    {

        
        protected Student stud;
        public StatsForStudent2(Student temp)
        {   
            
            this.stud = temp;
            InitializeComponent();
        }
        public Form RefToLastForm { get; set; }
        private void StatsForStudent2_Load(object sender, EventArgs e)
        {
            float Final_points = (150F - this.stud.calcTotalPoints());
            this.label1.Text = stud.getName();
            this.label3.Text = this.stud.calcTotalPoints().ToString();
            this.label6.Text =Final_points.ToString() ;
            this.label9.Text = this.stud.getID();
            this.label11.Text = this.stud.getDep();
            if (this.stud.getStatus())
                this.label13.Text = "Active";
            else
                this.label13.Text = "Blocked";

            this.label15.Text = this.stud.getSemester();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefToLastForm.Show();
            this.Close();
        }
    }
}
