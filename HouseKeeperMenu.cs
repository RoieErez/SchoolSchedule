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


namespace BS_project2
{
    public partial class HouseKeeperMenu : Form
    {
        HouseKeeper houseKeeper;
        public Form RefToMainMenu { get; set; }
        public HouseKeeperMenu(HouseKeeper temp)
        {
            InitializeComponent();
            houseKeeper = temp;
        }

        private void button1_Click(object sender, EventArgs e)  //  create report
        {
            ClassStatistics cl = new ClassStatistics(this.houseKeeper);
            cl.RefToLastForm = this;
            this.Visible = false;
            cl.Show();
        }

        private void button2_Click(object sender, EventArgs e)  //  Show Classes
        {
            ListOfClasses L = new ListOfClasses();
            L.RefToLastForm = this;
            this.Visible = false;
            L.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.RefToMainMenu.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void HouseKeeperMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + houseKeeper.getName();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass(houseKeeper);
            cp.RefToLastForm = this;
            this.Visible = false;
            cp.Show();
        }
    }

}
