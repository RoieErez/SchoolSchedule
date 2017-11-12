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
    public partial class TS_MySchedule : Form
    {
        private CTeachingStaff TS;
        private string day ;
        public TS_MySchedule()
        {
            InitializeComponent();
        }
        public TS_MySchedule(CTeachingStaff ts) : this()
        {
            TS = ts;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            day = "Sunday";
            setColor(1);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            day = "Monday";
            setColor(2);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            day = "Tuesday";
            setColor(3);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            day = "Wednesday";
            setColor(4);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            day = "Thursday";
            setColor(5);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            day = "Friday";
            setColor(6);
            listView1.Items.Clear();
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);
        }
        private void setColor(int day)
        {
            sundayP.BackColor = Color.Empty;
            mondayP.BackColor = Color.Empty;
            tuesdayP.BackColor = Color.Empty;
            ThurP.BackColor = Color.Empty;
            fridayP.BackColor = Color.Empty;
            wendsP.BackColor = Color.Empty;
            if (day == 1)
                sundayP.BackColor = Color.Black;
            if (day == 2)
                mondayP.BackColor = Color.Black;
            if (day == 3)
                tuesdayP.BackColor = Color.Black;
            if (day == 4)
                wendsP.BackColor = Color.Black;
            if (day == 5)
                ThurP.BackColor = Color.Black;
            if (day == 6)
                fridayP.BackColor = Color.Black;

        }

        private void TS_MySchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TS_MySchedule_Load(object sender, EventArgs e)
        {
            day = "Sunday";
            setColor(1);
            List<ListViewItem> list = TS.getLessonsByDay(day);
            for (int i = 0; i < list.Count; i++)
                listView1.Items.Add(list[i]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeachingStaffMenu form = new TeachingStaffMenu(TS);
            this.Hide();
            this.Closed += (s, args) => this.Close();
            form.Show();
        }

    }
}
