using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using BS_project2.Classes;

namespace BS_project2
{
    public partial class SecretaryMessage : Form
    {
        private Secretary secretary;
        String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Form RefToLastForm { get; set; }

        public SecretaryMessage(Secretary temp)
        {
            InitializeComponent();
            secretary = temp;
        }

        private void SecretaryMessage_Load(object sender, EventArgs e)
        {
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand("select * from SecMes", conDataBase);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Receiver Like '%{0}%'", secretary.getID());

                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)  //  delete message button
        {
            try
            {
                if (MessageBox.Show("Are you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(constring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM SecMes WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentCell.Value);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Choose full row please!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)  //  exit button
        {
            this.RefToLastForm.Show();                      //  new exit button
            this.Close();                                   //  working... (Tal)
        }

        private void button2_Click(object sender, EventArgs e)  //  send new message
        {
            SecretaryMSGSending HA = new SecretaryMSGSending(secretary);
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SecretaryReplyMSG HA = new SecretaryReplyMSG(secretary, dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
            HA.RefToLastForm = this;
            this.Visible = false;
            HA.Show();
        }
    }
}
