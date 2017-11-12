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
    public partial class Admin_Add_class : Form
    {
        private CAdministration ADS;
        public Admin_Add_class()
        {
            InitializeComponent();
        }
        public Admin_Add_class(CAdministration ads)
        {
            InitializeComponent();
            ADS = ads;
        }

        private void Admin_Add_class_Load(object sender, EventArgs e)
        {

        }

        private void Admin_Add_class_FormClosed(object sender, FormClosedEventArgs e)
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string acc=null;
            bool f = false;
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                acc +="Projector " ;
            
            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
                acc +="Computer ";
            
            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
                acc += "Disabled accessible";


            if (checkBox1.CheckState == CheckState.Checked)
                f = true;
            if(IDText.Text.Count() == 0)
            {
                MessageBox.Show("Must enter class name");
                return;
            }
            if (capacity.Text.Count() == 0)
            {
                MessageBox.Show("Must enter class capacity");
                return;
            }
            if (ADS.addClass(IDText.Text.ToString(), Convert.ToInt32(capacity.Text), acc, f))
                MessageBox.Show("add class successfully!");
           
        }
    }
}
