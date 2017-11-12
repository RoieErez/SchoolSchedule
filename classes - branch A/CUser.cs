using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BS_project2
{
    public abstract class CUser
    {
        private String id;
        public string Id { get { return id; } }
        private String name;
        public string Name { get { return name; }  }
        private String password;
        public string Password { get { return password; } set { password = value; } }
        private String department;
        public string Department { get { return department; } set { department = value; } }
        private String permission;
        public string Permission { get { return permission; }  }

        public CUser(String ID, String Name, String Password, String Department, String Permission)
        {/*constructor*/
            id = ID;
            name = Name;
            password = Password;
            department = Department;
            permission = Permission;

        }

        public static Form LogIn(String id, String pass)
        {/*login to system*/
            DataTable t, dt = Program.get_dt("Select * from Login where Id='" + id + "' and Password='" + pass + "'");
            
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][3].Equals("HOD"))
                {
                    HeadOfDepart_Main HA = new HeadOfDepart_Main(new CHeadOfDepartment(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString()));
                    return HA;
                }
                if (dt.Rows[0][3].Equals("TS"))
                {
                    t = Program.get_dt("Select * from Teaching_Staff where Id='" + id +"'");
                    TeachingStaffMenu Ts = new TeachingStaffMenu(new CTeachingStaff(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString(),t.Rows[0][1].ToString(),t.Rows[0][2].ToString()));
                    return Ts;
                }
                if (dt.Rows[0][3].Equals("SEC"))
                {
                    SecretaryFolder.Secretary_Menu Sec = new SecretaryFolder.Secretary_Menu(new CSecretary(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString()));
                    return Sec;
                }
                if (dt.Rows[0][3].Equals("ADS"))
                {
                    Administration.Administration_main Es = new Administration.Administration_main(new CAdministration(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][3].ToString()));
                    return Es;
                }

                //Branch B///
                if (dt.Rows[0][3].Equals("Student"))
                {
                    String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    SqlConnection con = new SqlConnection(conect);
                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from Students where ID = '" + dt.Rows[0][0] + "'", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    Student student = new Student(dt2.Rows[0][1].ToString(), dt2.Rows[0][0].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString(), dt2.Rows[0][3].ToString(), (bool)dt2.Rows[0][4]);

                    //first entrance of the student
                    //need to change his initial password
                    if (dt.Rows[0][0].Equals(dt.Rows[0][2]))//initial password equals ID
                    {
                        InitPassChange FM = new InitPassChange();
                        FM.RefToLastForm = new Login();

                        return FM;
                    }
                    //not the first entrence of the student
                    else
                    {
                        if (!student.getStatus())
                        {
                            MessageBox.Show("Your student's status is NOT active,\nplease go to 'Student's Accounts'");
                        }
                        else
                        {
                            StudentMenu HA = new StudentMenu(student);
                            HA.RefToMainMenu = new Login();
                            return HA;
                        }
                    }
                }
                if (dt.Rows[0][3].Equals("Secretary"))
                {
                    String conect = @"Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    SqlConnection con = new SqlConnection(conect);
                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from Secretary;", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    Secretary secretery = new Secretary(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt2.Rows[0][2].ToString());
                    SecretaryMenu HA = new SecretaryMenu(secretery);
                    HA.RefToMainMenu = new Login();
             
                    return HA;
                }
                if (dt.Rows[0][3].Equals("President"))
                {
                    President president = new President(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    PresidentMenu HA = new PresidentMenu(president);
                    HA.RefToMainMenu = new Login();

                    return HA;
                }
                if (dt.Rows[0][3].Equals("HK"))
                {
                    HouseKeeper houseKeeper = new HouseKeeper(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    HouseKeeperMenu HA = new HouseKeeperMenu(houseKeeper);
                    HA.RefToMainMenu = new Login();

                    return HA;
                }

            }
          
            return new Login();
        }

        public static void LogOut()
        {/*exit from system*/
            Login f1 = new Login();
            f1.Show();
            
        }

         public  bool ChangePassword(string pass)
        {/*change password in data base*/
            return Program.update_sql("UPDATE Login SET Password = '" + pass+ "' WHERE Id ='" + id + "'");
            
        }
     }
}

