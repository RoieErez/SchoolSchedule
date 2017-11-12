using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using System.Dynamic;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace BS_project2
{
    public partial class LoginFacebook : Form
    {
        private long client_id;
        private string succ;
        private string responesUrl;
        private string user_fb_id;
        private string token;

        public LoginFacebook()
        {
            InitializeComponent();
            // SET VARIABLES
            //this.client_id = 1239132142925481;
            this.client_id = 223334788168553;
            this.succ = "https://www.facebook.com/connect/login_success.html";
            this.webBrowser.Url = new Uri("https://www.facebook.com/v2.9/dialog/oauth?display=popup&response_type=token&client_id="
            + client_id
            + "&redirect_uri=" + succ);
        }

        private void LoginFacebook_Load(object sender, EventArgs e)
        {
        }

        public static string GetLogoutURL(string AccessToken)
        {
            var fb = new FacebookClient();
            var logoutUrl = fb.GetLogoutUrl(new { access_token = AccessToken, next = "https://www.facebook.com/connect/login_success.html" });
            return logoutUrl.ToString();
        }

        public String info()
        {
            // call facebook for data
            String[]s;
            string json = string.Empty;
            string url = @"https://graph.facebook.com/v2.9/me?fields=id%2Cname&access_token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            json=json.Trim('{','}');
            s = json.Split('"');
            return s[3];//id
        }

        private void webBrowser_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // IF IT NAVIGATE TO SUCCESS, GRAB THE TOKEN
            if (e.Url.ToString().Contains("#access_token="))
            {
                responesUrl = e.Url.ToString();
                int start_token = responesUrl.IndexOf("=");
                int end_token = responesUrl.IndexOf("&expires_in");
                int len = end_token - start_token - 1;
                token = responesUrl.Substring(start_token + 1, len);
                this.webBrowser.Navigate("https://flexsurveys.com/wp-content/uploads/Employee-Survey-Successful.png");
                this.user_fb_id = info();

                DataTable dt = Program.get_dt("SELECT * FROM Login WHERE FB_id='" + this.user_fb_id + "'");
                if(dt.Rows.Count==0)
                {
                    DialogResult dialogResult = MessageBox.Show("You must activate your acount with Facebook\n Activate now?", "Activate Facebook", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.ActivateFB(this.user_fb_id);
                        f.Show();

                    }
                    if (dialogResult == DialogResult.No)
                    {
                        this.webBrowser.Navigate(GetLogoutURL(token));//logout
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.Login();
                        f.Show();
                    }
                   
                }
                else
                //chaking permission
                {
                    if (dt.Rows[0][3].ToString().Equals("ADS"))//Aadmin
                    {
                        CAdministration User = new CAdministration(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString());
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.Administration.Administration_main(User);
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        f.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("TS"))//Teaching stuff
                    {
                        DataTable dt2 = Program.get_dt("SELECT Type,Constraints FROM Teaching_staff WHERE id='" + dt.Rows[0][0].ToString() + "'");
                        CTeachingStaff User = new CTeachingStaff(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString(),dt2.Rows[0][0].ToString(), dt2.Rows[0][1].ToString());
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.TeachingStaffMenu(User);
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        f.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("SEC"))//Secratry
                    {
                        CSecretary User = new CSecretary(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString());
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.SecretaryFolder.Secretary_Menu(User);
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        f.Show();

                    }
                    else if (dt.Rows[0][3].ToString().Equals("HOD"))//Head of department
                    {
                        CHeadOfDepartment User = new CHeadOfDepartment(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString());
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        Form f = new BS_project2.HeadOfDepart_Main(User);
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        f.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("Student"))//student
                    {
                        String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                        System.Data.SqlClient.SqlConnection con = new SqlConnection(conect);
                        SqlDataAdapter sda2 = new SqlDataAdapter("select * from Students where ID = '" + dt.Rows[0][0] + "'", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        Student student = new Student(dt2.Rows[0][1].ToString(), dt2.Rows[0][0].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString(), dt2.Rows[0][3].ToString(), (bool)dt2.Rows[0][4]);

                        StudentMenu HA = new StudentMenu(student);
                        HA.RefToMainMenu = new Login();
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        HA.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("Secretary"))//secretary2
                    {
                        String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                        SqlConnection con = new SqlConnection(conect);
                        SqlDataAdapter sda2 = new SqlDataAdapter("select * from Secretary;", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);

                        Secretary secretery = new Secretary(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString());
                        SecretaryMenu HA = new SecretaryMenu(secretery);
                        HA.RefToMainMenu = new Login();
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        HA.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("HK"))//HK
                    {
                        HouseKeeper houseKeeper = new HouseKeeper(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                        HouseKeeperMenu HA = new HouseKeeperMenu(houseKeeper);
                        HA.RefToMainMenu = new Login();
                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        HA.Show();
                    }
                    else if (dt.Rows[0][3].ToString().Equals("President"))//president
                    {
                        President president = new President(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                        PresidentMenu HA = new PresidentMenu(president);
                        HA.RefToMainMenu = new Login();

                        this.Hide();
                        this.Closed += (s, args) => this.Close();
                        webBrowser.Navigate(GetLogoutURL(token));//logout
                        HA.Show();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            Form f = new BS_project2.Login();
            f.Show();
        }

        private void LoginFacebook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Closed += (s, args) => this.Close();
            Form f = new BS_project2.Login();
            f.Show();
        }
    }
}
