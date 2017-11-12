using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace BS_project2
{
    public class CSecretary: CUser
    {


        public CSecretary(String ID, String Name, String Pass, String Dep, String Per) : base(ID, Name, Pass, Dep, Per) {/*constructor*/ } 
        public DataTable SeeTSconstraints()
        {
            return  Program.get_dt("SELECT E.F_Name NAME, D.Constraints,D.type,E.id FROM Login E JOIN Teaching_staff D ON(E.Id = D.Id AND E.Department ='" + Department + "')");
            
        }
        public DataTable getCoursesBySem(string sem)
        {

            return Program.get_dt("select id,name,semester from courses where department='"+Department+"' and semester='"+sem+"'");
        }
        public int getNumOfStudents(String sem)
        {
           return Program.get_dt("select name from students where department ='"+Department+"' and semester='"+sem+"'" ).Rows.Count;
        }
        public List<string> getTsByCourseAssignment(string courseID)
        {
            DataTable id=Program.get_dt("select id from Lecturer_prac_assignment where courseid='" + courseID + "'");
            DataTable dt = Program.get_dt("select id,f_name from login where department='" + this.Department + "'");
            List<string> names = new List<string>();

            for (int i = 0; i < id.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (id.Rows[i][0].ToString() == dt.Rows[j][0].ToString())
                        names.Add(dt.Rows[j][1].ToString());
                }
            }
            return names;
        }
        public bool AddLesson(string lessonType, string semester, string courseID, string day, string start, string end, string TSID, string Class)
        {
            if(string.Compare(start,end)>=0)
            {
                MessageBox.Show("Invalid hours");
                return false;
            }
            DataTable lessons= Program.get_dt("select * from lessons left join courses on(lessons.courseid = courses.id and courses.department = '"+this.Department+"')");
            DataTable TS = Program.get_dt("select day,starth,endh from lessons where TSID='" + TSID + "'");
            DataTable teacher = Program.get_dt("select f_name from login where id='" + TSID + "'");
            Dictionary<string, int> dict=  new Dictionary<string, int>();
            dict.Add("Sunday", 1);
            dict.Add("Monday", 2);
            dict.Add("Tuesday", 3);
            dict.Add("Wednesday", 4);
            dict.Add("Thursday", 5);
            dict.Add("Friday", 6);


            int countLec = 0;
            /*check if adding prac before lec - false*/
            if (lessonType == "Prac")
            {
                for (int i = 0; i < lessons.Rows.Count; i++)
                {
                    if (lessons.Rows[i][3].ToString() == courseID)
                    {
                        if (lessons.Rows[i][1].ToString() == "Lec")
                        {
                            countLec++;
                        }
                    }
                }
                if (countLec == 0)
                {
                    MessageBox.Show("Must add lecture before adding praction");
                    return false;
                }
            }
           

           
            /*checking for adding prac after lec*/
            if (lessonType == "Prac")
            {
                for (int i = 0; i < lessons.Rows.Count; i++)
                {
                    /*same course*/
                    if (lessons.Rows[i][3].ToString() == courseID && lessons.Rows[i][1].ToString() == "Lec" )
                    {
                        countLec--;
                        if (dict[lessons.Rows[i][4].ToString()] > dict[day] && countLec == 0)
                        {
                            MessageBox.Show("Must add lecture before praction");
                            return false;
                        }
                        else if(dict[lessons.Rows[i][4].ToString()] == dict[day] )
                        {
                            if (string.Compare(start,lessons.Rows[i][6].ToString())==-1 && countLec == 0)
                            {
                                MessageBox.Show("Praction must start after lecture");
                                return false;
                            }
                        }
                    }
                }
            }
            /*check if TS allready have lessons on the same hours of the new lesson*/
           
            for (int i=0;i<TS.Rows.Count;i++)
            {
                if(TS.Rows[i][0].ToString()==day)
                {
              
                    if(!notSameTime(start, TS.Rows[i][1].ToString(), end, TS.Rows[i][2].ToString()))
                    {
                        MessageBox.Show(teacher.Rows[0][0].ToString() + " allready have a lesson at this time");
                        return false;
                    }
                }
            }
            
            return Program.update_sql("insert into lessons values('" + lessonType + "','" + semester + "','" + courseID + "','" + day + "','" + start + "','" + end + "','" + TSID + "','" + Class + "')");
           
            
        }
        public bool notSameTime(string start,string start2,string end,string end2)
        {

            if (string.Compare(start, start2) >= 0 && string.Compare(start, end2) < 0)

                return false;
            
            if (string.Compare(end, start2) > 0 && string.Compare(end, end2) <= 0)
                return false;
            
            if (string.Compare(start,start2) <= 0 && string.Compare(end, end2) >= 0)
           
                return false;
            
            return true;
        }
        public List<ListViewItem> getLessonsByDay(string day,string semester)
        {
            DataTable lessons= Program.get_dt("select L.startH, L.endH, C.Name, L.lessontype, G.F_Name,"
                +"L.classname,L.lessonID from[lessons] L join courses C on l.CourseID = c.Id join login G on L.TSID ="
                +"g.Id where l.Day ='"+day+ "'and c.semester ='" + semester+ "' and c.department ='"+Department+"' order by starth");

            List<ListViewItem> list = new List<ListViewItem>();
            ListViewItem temp;
            for (int i=0;i<lessons.Rows.Count;i++)
            {
                temp = getListViewItem(lessons.Rows[i][0].ToString());
                temp.SubItems.Add(lessons.Rows[i][1].ToString());
                temp.SubItems.Add(lessons.Rows[i][2].ToString()+"-"+ lessons.Rows[i][3].ToString());
                temp.SubItems.Add(lessons.Rows[i][4].ToString());
                temp.SubItems.Add(lessons.Rows[i][5].ToString());
                temp.SubItems.Add(lessons.Rows[i][6].ToString());
                list.Add(temp);

            }
            return list;


        
        }
        private ListViewItem getListViewItem(string start)
        {
           ListViewItem l = new ListViewItem(start);
            return l;
        }
        public bool deleteLesson(string id)
        {

            return Program.update_sql("delete from lessons where lessonid='"+id+"'");
        }
    }

}
