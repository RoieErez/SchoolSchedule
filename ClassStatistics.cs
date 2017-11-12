using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BS_project2.Classes
{
    public partial class ClassStatistics : Form
    {
        string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form RefToLastForm { get; set; }

        HouseKeeper houseKeeper;

        public ClassStatistics(HouseKeeper temp)
        {
            InitializeComponent();
            houseKeeper = temp;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClassStatistics_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id from Classes";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
                comboBox1.Items.Add(dr["Id"].ToString());
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res;
            SqlConnection conDataBase = new SqlConnection(connect);
            SqlCommand cmdDataBase = new SqlCommand("select StartH,EndH from Lessons where ClassName='"+comboBox1.SelectedItem.ToString()+"'", conDataBase);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dt = new DataTable();
               
                sda.Fill(dt);

               // DataView dv = new DataView(dt);
                //dv.RowFilter = string.Format("Receiver Like '%{0}%'",comboBox1.SelectedItem.ToString());
                //DataTable ds = new DataTable();
               
                res=houseKeeper.getClassStatistics(dt);
                label2.Text = res+" weakly hours occcupied";
                label2.Visible = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();
        }
    }
}
