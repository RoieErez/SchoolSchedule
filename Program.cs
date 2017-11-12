using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BS_project2
{
    public static class Program
    {

        public static bool chackId(string s)

        {
            if (s.Length != 9) return false;

            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i]) == false)
                    return false;
            return true;
        }
        public static bool update_sql(String query)
        {
            String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(conect);
            SqlCommand com = con.CreateCommand();
            com.CommandText = query;
            con.Open();
            try
            {
                com.ExecuteNonQuery();
            }
           catch (SqlException )
            {
                return false;
            }
            
            con.Close();
            return true;
        }
        public static DataTable get_dt(String command)
        {
            DataTable dt = new DataTable();
            try
            {
                string conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection con = new SqlConnection(conect);
                SqlDataAdapter sda = new SqlDataAdapter(command, con);
                sda.Fill(dt);
                return dt;
            }
            catch (SqlException) { MessageBox.Show("SQL Error"); }
            return null;
        }
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
