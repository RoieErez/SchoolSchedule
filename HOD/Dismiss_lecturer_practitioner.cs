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
    public partial class Dismiss_lecturer_practitioner : Form
    {
        private CHeadOfDepartment Hod;
        private DataTable TS;
        public Dismiss_lecturer_practitioner(CHeadOfDepartment obj)
        {
            InitializeComponent();
            Hod = obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeadOfDepart_Main f1 = new HeadOfDepart_Main(Hod);

            this.Hide();
            this.Closed += (s, args) => this.Close();
            f1.Show();

        }

        private void Dismiss_lecturer_practitioner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (chooseTS.SelectedIndex ==-1)
            {
                MessageBox.Show("Must choose lecturer");
                return;
            }
            DataTable dt = Program.get_dt("select tsid from lessons where tsid='" +TS.Rows[chooseTS.SelectedIndex][1].ToString() + "'");
            if(dt.Rows.Count>0)
            {
                MessageBox.Show("Teaching Staff cannot be dissmised\n Teaching Staff assigned to lessons");
                return;
            }
               
            if (Hod.DismissTeachingStaff(TS.Rows[chooseTS.SelectedIndex][1].ToString()))
            {
                MessageBox.Show("deleted succesfully");
                chooseTS.SelectedIndex = -1;
                chooseTS.Items.Clear();
                TS = Program.get_dt("select f_name,id from login where permission='TS' and department='" + Hod.Department + "' order by f_name");
                for (int i = 0; i < TS.Rows.Count; i++)
                    chooseTS.Items.Add(TS.Rows[i][0]);
            }
                
            else
                MessageBox.Show("not found");

        }

        private void Dismiss_lecturer_practitioner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Dismiss_lecturer_practitioner_Load(object sender, EventArgs e)
        {
            TS = Program.get_dt("select f_name,id from login where permission='TS' and department='" + Hod.Department + "' order by f_name");
            for (int i = 0; i < TS.Rows.Count; i++)
                chooseTS.Items.Add(TS.Rows[i][0]);

        }
    }
}
