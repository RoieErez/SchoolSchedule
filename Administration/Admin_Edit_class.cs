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
    public partial class Admin_Edit_class : Form
    {
        private CAdministration ADS;
        public Admin_Edit_class()
        {
            InitializeComponent();
        }
        public Admin_Edit_class(CAdministration ads)
        {
            InitializeComponent();
            ADS = ads;
        }

        private void Admin_Edit_class_Load(object sender, EventArgs e)
        {
            DataTable T = Program.get_dt("SELECT * from classes");
            if (T.Rows.Count < 0)
                return;
            for (int i = 0; i < T.Rows.Count; i++)
            {
                comboBox1.Items.Add(T.Rows[i][0]);
            }
        }

        private void Admin_Edit_class_FormClosed(object sender, FormClosedEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string acc = null;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose class");
                return;
            }
            if (textBox1.Text.Count() <1)
            {
                MessageBox.Show("Must enter capacity");
                return;
            }
            DataTable t = Program.get_dt("select classname from lessons where classname = '" + comboBox1.SelectedItem.ToString() + "'");
            if (t.Rows.Count > 0)
            {
                MessageBox.Show("Cannot edit class details,class allready assign to lesson");
                return;

            }
           

            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                acc += "Projector ";

            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
                acc += "Computer ";

            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
                acc += "Disabled accessible";



            if (ADS.editClassDetails(comboBox1.GetItemText(comboBox1.SelectedItem), Convert.ToInt32(textBox1.Text), acc))
                MessageBox.Show("Edit class success");
            
        }
    }
}
