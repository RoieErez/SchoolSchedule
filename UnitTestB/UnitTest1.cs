using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS_project2;
using BS_project2.Classes;
using System.Data.SqlClient;
using System.Data;

namespace UnitTestB
{



    [TestClass]
   
    public class CUserTest
    {
      

        [TestMethod]
        public void ChangePasswordTest()
        {
             CUser u = new CTeachingStaff("test", "test", "123456", "Software", "TS", "Lecturer", null);
            Program.update_sql("insert into login values('" + u.Id + "','" + u.Name + "','" + u.Password + "','" + u.Permission + "','" + u.Department + "','NULL')");
            u.ChangePassword("123456");
            DataTable dt = Program.get_dt("SELECT password from Login WHERE Id='" + u.Id + "'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == u.Password);
            Program.update_sql("DELETE login WHERE id='TEST'");
        }

    }
   
    [TestClass]
    public class TeachingStaffTest
    {
        [TestMethod]
        public void addConstraintsToDBTest()
        {

            CTeachingStaff t = new CTeachingStaff("test", "test", "test", "test", "test", "Lecturer", "abcd");
            Program.update_sql("insert into login values('" + t.Id + "','" + t.Name + "','" + t.Password + "','" + t.Permission + "','" + t.Department + "','NULL')");
            Program.update_sql("insert into teaching_staff values('" + t.Id + "','" + t.Type + "','test')");
            t.addConstraintsToDB();
            DataTable dt = Program.get_dt("SELECT constraints from Teaching_staff WHERE Id='" + t.Id + "'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == t.Constraints);
            Program.update_sql("DELETE TEACHING_STAFF WHERE id='test'");
            Program.update_sql("DELETE login WHERE id='test'");
        }
    }

    [TestClass]
    public class AdministrationTest
    {
        [TestMethod]
        public void addClassTest()
        {
            Class c = new Class("test", "", true, 50);
            CAdministration a = new CAdministration("test", "test", "123", "Software", "AD");
            a.addClass(c.Id, c.Cacpacity, c.Accessories, c.Lab);
            DataTable dt = Program.get_dt("SELECT * from classes WHERE Id='" + c.Id + "'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == c.Id && dt.Rows[0][1].Equals(c.Cacpacity) && dt.Rows[0][2].ToString() == c.Accessories && dt.Rows[0][3].Equals(c.Lab));
            Program.update_sql("DELETE classes WHERE id='TEST'");



        }

        [TestMethod]
        public void removeClassTest()
        {
            Class c = new Class("test", "", true, 50);
            CAdministration a = new CAdministration("test", "test", "123", "Software", "AD");
            a.removeClass(c.Id);
            DataTable dt = Program.get_dt("SELECT * from classes WHERE Id='" + c.Id + "'");
            Assert.IsTrue(dt.Rows.Count == 0);
            Program.update_sql("DELETE classes WHERE id='TEST'");
        }

        [TestMethod]
        public void showDetailsTest()
        {
            Class c = new Class("test", "", true, 50);
            CAdministration a = new CAdministration("test", "test", "123", "Software", "AD");
            a.addClass(c.Id, c.Cacpacity, c.Accessories, c.Lab);
            DataTable dt = a.showDetails(c.Id);
            Assert.IsTrue(dt.Rows[0][0].ToString() == c.Id && dt.Rows[0][1].Equals(c.Cacpacity) && dt.Rows[0][2].ToString() == c.Accessories && dt.Rows[0][3].Equals(c.Lab));
            Program.update_sql("DELETE classes WHERE id='TEST'");

        }

        [TestMethod]
        public void editClassDetailsTest()
        {
            Class c = new Class("test", "", true, 50);
            CAdministration a = new CAdministration("test", "test", "123", "Software", "AD");
            a.addClass(c.Id, c.Cacpacity, c.Accessories, c.Lab);
            a.editClassDetails(c.Id, 55, "change");
            DataTable dt = Program.get_dt("SELECT * from classes WHERE Id='" + c.Id + "'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == c.Id && dt.Rows[0][1].Equals(55) && dt.Rows[0][2].ToString() == "change" && dt.Rows[0][3].Equals(c.Lab));
            Program.update_sql("DELETE classes WHERE id='TEST'");
        }

        [TestMethod]
        public void addStudentTest()
        {
            CAdministration a = new CAdministration("test", "test", "123", "Software", "AD");
            a.addStudent("test", "test", "test", "test");
            DataTable dt = Program.get_dt("SELECT * from students WHERE Id='test'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == "test" && dt.Rows[0][1].ToString() == "test" && dt.Rows[0][2].ToString() == "test" && dt.Rows[0][3].ToString() == "test");
            Program.update_sql("DELETE students WHERE id='TEST'");
            Program.update_sql("DELETE login WHERE id='TEST'");


        }
    }

    /*HOD test */
    [TestClass]
    public class HODTest
    {
        [TestMethod]
        public void DismissTeachingStaffTest()
        {
            CHeadOfDepartment hod = new CHeadOfDepartment("test", "test", "test", "test", "test");
            CTeachingStaff ts = new CTeachingStaff("test", "test", "test", "test", "test", "Lecturer", null);
            Program.update_sql("insert into login values('" + ts.Id + "','" + ts.Name + "','" + ts.Password + "','" + ts.Permission + "','" + ts.Department + "')");
            Program.update_sql("insert into teaching_staff values('" + ts.Id + "','" + ts.Type + "','" + ts.Constraints + "')");
            hod.DismissTeachingStaff(ts.Id);
            DataTable dt = Program.get_dt("SELECT * from teaching_staff WHERE Id='test'");
            DataTable dt2 = Program.get_dt("SELECT * from login WHERE Id='test'");
            Assert.IsTrue(dt.Rows.Count == 0 && dt2.Rows.Count == 0);


        }

        [TestMethod]
        public void addSecretaryTest()
        {
            CHeadOfDepartment hod = new CHeadOfDepartment("test", "test", "test", "test", "test");
            CSecretary s = new CSecretary("test", "test", "test", "test", "test");
            hod.addSecretary(s.Id, s.Name);
            DataTable dt = Program.get_dt("SELECT id,f_name from login WHERE Id='test'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == s.Id && dt.Rows[0][1].ToString() == s.Name);
            Program.update_sql("DELETE login WHERE id='TEST'");

        }

        [TestMethod]
        public void dismissSecretaryTest()
        {
            CHeadOfDepartment hod = new CHeadOfDepartment("test", "test", "test", "test", "test");
            CSecretary s = new CSecretary("test", "test", "test", "test", "test");
            hod.addSecretary(s.Id, s.Name);
            hod.dismissSecretary(s.Id);
            DataTable dt = Program.get_dt("SELECT id from login WHERE Id='test'");
            Assert.IsTrue(dt.Rows.Count == 0);


        }

        [TestMethod]
        public void AddLecturer_PracAssignmentTest()
        {
            CHeadOfDepartment hod = new CHeadOfDepartment("test", "test", "test", "test", "test");
            hod.AddLecturer_PracAssignment("test", "test");
            DataTable dt = Program.get_dt("SELECT * from Lecturer_prac_assignment WHERE courseId='test'");
            Assert.IsTrue(dt.Rows[0][0].ToString() == "test" && dt.Rows[0][1].ToString() == "test");
            Program.update_sql("DELETE Lecturer_prac_assignment WHERE courseid='TEST'");
        }

    }


    [TestClass]
    public class UnitTest1
    {
        String forcheck = "jnljnf";
        Boolean flag = true;
        Student temp = new Student("113424", "doron", "8648648", "Software engineering", "A", true);
        static string connect = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(connect);
        [TestMethod]
        public void Test_check_input1_student()
        {
            
            
            Assert.IsTrue(flag == temp.Check_InPut(forcheck));
            

        }
        [TestMethod]
        public void Test_check_input2_student()
        {
            flag = false;
            forcheck = "fsdf dfvd";
            Assert.IsTrue(flag == temp.Check_InPut(forcheck));
        }
        
        
        [TestMethod]
        public void test_calcTotalPoints_student()
        {
            int num = 0;
            Student temp = new Student("test", "test", "test", "test test", "test", true);
            String text = "INSERT INTO Students(Name,ID,Department,Semester,Active)value('" + temp.getName() + "'" + "'" + temp.getID() + "'" + temp.getDep() + "'" + temp.getSemester() + "'" + temp.getStatus() + "'" + ")";
            Program.update_sql(text);
            SqlConnection con = new SqlConnection(connect);
            Assert.IsTrue(num == temp.calcTotalPoints());
            Program.update_sql("DELETE Students WHERE Name='" + temp.getName() + "'");
        }
        [TestMethod]
        public void test_changedetailbutton()
        {
            String constring = "Server=tcp:project-1.database.windows.net,1433;Initial Catalog=Data;Persist Security Info=False;User ID=Admin1;Password=Ad123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(constring);
            Student temp = new Student("test", "test", "test", "test test", "test", true);
            String nametocheck = "aaa bbb";
            String text = "INSERT INTO Students(Name,ID,Department,Semester,Active)value('" + temp.getName() + "'" + "'" + temp.getID() + "'" + temp.getDep() + "'" + temp.getSemester() + "'" + temp.getStatus() + "'" + ")";
            Program.update_sql(text);
            temp.changedetailbutton("aaa", "bbb", con);
            Assert.IsTrue(nametocheck == temp.getName());
            Program.update_sql("DELETE Students WHERE Name='" + temp.getName() + "'");
        }
        

    }
    /*user class tests */
    [TestClass]
    public class UserTest
    {
        Student temp = new Student("test", "test", "test", "test test", "test", true);
        bool flag;
        String forcheck;
        [TestMethod]
        public void Test_setid1_user()
        {
            flag = true;
            forcheck = "864753";
            Assert.IsTrue(flag == temp.setID(forcheck));
        }
        [TestMethod]
        public void Test_setid2_user()
        {
            flag = false;
            forcheck = "";
            Assert.IsTrue(flag == temp.setID(forcheck));
        }
        [TestMethod]
        public void Test_setname1_user()
        {
            flag = false;
            forcheck = "";
            Assert.IsTrue(flag == temp.setName(forcheck));
        }
        [TestMethod]
        public void Test_setname2_user()
        {
            flag = true;
            forcheck = "doron";
            Assert.IsTrue(flag == temp.setName(forcheck));
        }
        [TestMethod]
        public void Test_setpass1_user()
        {
            flag = true;
            forcheck = "09759864";
            Assert.IsTrue(flag == temp.setPass(forcheck));
        }
        [TestMethod]
        public void Test_setpass2_user()
        {
            flag = false;
            forcheck = "";
            Assert.IsTrue(flag == temp.setPass(forcheck));
        }
        [TestMethod]
        public void test_changePass1()
        {
            String text = "INSERT INTO Students(Name,ID,Department,Semester,Active)value('" + temp.getName() + "'" + "'" + temp.getID() + "'" + temp.getDep() + "'" + temp.getSemester() + "'" + temp.getStatus() + "'" + ")";
            Program.update_sql(text);
            forcheck = "12345678";
            flag = true;
            Assert.IsTrue(flag == temp.changePass("test", forcheck, forcheck));
            Program.update_sql("DELETE Students WHERE Name='" + temp.getName() + "'");
        }
        [TestMethod]
        public void test_changePass2()
        {
            String text = "INSERT INTO Students(Name,ID,Department,Semester,Active)value('" + temp.getName() + "'" + "'" + temp.getID() + "'" + temp.getDep() + "'" + temp.getSemester() + "'" + temp.getStatus() + "'" + ")";
            Program.update_sql(text);
            forcheck = "12345678";
            flag = false;
            Assert.IsTrue(flag == temp.changePass("test", forcheck, "9876543"));
            Program.update_sql("DELETE Students WHERE Name='" + temp.getName() + "'");
        }
    }
    [TestClass]
    public class TestSecretaryB
    {
        Secretary s = new Secretary("113424", "doron", "8648648", "Software engineering");
        String forcheck = "";
        bool flag;
        [TestMethod]
        public void Test_setdepartment1_secretary()//secretary
        {
            flag = false;
            forcheck = "";
            Assert.IsTrue(flag == s.setDepartment(forcheck));
        }
        [TestMethod]
        public void Test_setdepartment2_secretary()
        {
            flag = true;
            forcheck = "shdfgdhfh";
            Assert.IsTrue(flag == s.setDepartment(forcheck));
        }
        [TestMethod]
        public void Test_getdepartment1_secretary()
        {
            flag = true;
            forcheck = "shdfgdhfh";
            s.setDepartment(forcheck);
            Assert.IsTrue(s.getDepartment().Equals("shdfgdhfh"));
        }
    }
}
