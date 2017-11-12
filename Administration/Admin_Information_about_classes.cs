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
    public partial class Admin_Information_about_classes : Form
    {
        private CAdministration ADS;
        public Admin_Information_about_classes()
        {
            InitializeComponent();
        }
        public Admin_Information_about_classes(CAdministration ads)
        {
            InitializeComponent();
            ADS = ads;
        }
        private void Admin_Information_about_classes_Load(object sender, EventArgs e)
        {
            DataTable T = Program.get_dt("SELECT * from classes");
            for (int i = 0; i < T.Rows.Count; i++)
            {
                comboBox1.Items.Add(T.Rows[i][0]);
            }
        }

        private void Admin_Information_about_classes_FormClosed(object sender, FormClosedEventArgs e)
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
            if (comboBox1.SelectedIndex != -1)
            {
                string s;
                DataTable dt = ADS.showDetails(comboBox1.GetItemText(comboBox1.SelectedItem));
                if (dt == null)
                    MessageBox.Show("Could not retrive class details!");
                else
                {
                    if (dt.Rows[0][3].ToString() == "True")
                        s = "Laboratory";
                    else
                        s = "Class room";
                    MessageBox.Show("Id: " + dt.Rows[0][0].ToString() + "\n" + "Capacity: " + dt.Rows[0][1].ToString() + "\n" + "Accessories: " + dt.Rows[0][2].ToString() + "\n" + "Class type: " + s + "\n");
                }
            }
            else
                MessageBox.Show("Must choose Class");
        }
    }
}
