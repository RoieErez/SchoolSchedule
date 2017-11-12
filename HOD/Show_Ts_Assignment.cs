using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2.HOD
{
    public partial class Show_Ts_Assignment : Form
    {
        private CHeadOfDepartment Hod;
        private DataTable t;
        public Show_Ts_Assignment()
        {
            InitializeComponent();
        }
        public Show_Ts_Assignment(CHeadOfDepartment hod):this()
        {
            Hod = hod;
        }

        private void Show_Ts_Assignment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Show_Ts_Assignment_Load(object sender, EventArgs e)
        {
            t = Program.get_dt("Select Id,F_Name from Login Where Department ='" + Hod.Department + "'" + " and Permission =" + "'TS'");
            for (int i = 0; i < t.Rows.Count; i++)
                comboBox1.Items.Add(t.Rows[i][1].ToString());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose teaching staff");
                return;
            }
            listView1.Items.Clear();
            if(!Hod.ShowTSAssignment(listView1,  t.Rows[comboBox1.SelectedIndex][0].ToString()))
                MessageBox.Show("No assignment for this teaching staff");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();

        }
    }
}
