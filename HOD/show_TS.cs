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
    public partial class show_TS : Form
    {
        private CHeadOfDepartment Hod;
        public show_TS()
        {
            InitializeComponent();
        }
        public show_TS(CHeadOfDepartment h):this()
        {
            Hod = h;
        }



        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void show_TS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void show_TS_Load(object sender, EventArgs e)
        {/*show all teaching staff on department*/

            DataTable dt = Program.get_dt("SELECT f_name,id FROM Login where department='" + Hod.Department + "' and permission='TS'");
            if (dt.Rows.Count > 0)
            {
                DataTable dt2 = Program.get_dt("select * from Teaching_staff");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {

                        if (dt.Rows[i][1].ToString() == dt2.Rows[j][0].ToString() && dt2.Rows[j][1].ToString() == "Lecturer")
                        {
                            listBox2.Items.Add(dt.Rows[i][0].ToString());
                        }
                        if (dt.Rows[i][1].ToString() == dt2.Rows[j][0].ToString() && dt2.Rows[j][1].ToString() == "Practioner")
                        {
                            listBox1.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }

                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            HeadOfDepart_Main f = new HeadOfDepart_Main(Hod);
            f.Show();
        }
    }
}
