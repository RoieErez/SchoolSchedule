using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_project2
{
    public class CTeachingStaff:CUser
    {
        private String constraints;
        public string Constraints { get { return constraints; } set { constraints = value; } }
        private string type;
        public string Type { get { return type; } set { type = value; } }

        public CTeachingStaff(String ID, String Name, String Pass, String Dep, String Per,string type,string constraints) :base(ID,Name,Pass,Dep,Per)
        {/*constructor*/
            this.type = type;
            this.constraints = constraints;

        }
        public bool addConstraintsToDB()
        {/*add teaching staff constraints to data base*/

            if (Program.update_sql("UPDATE Teaching_Staff SET Constraints = '" + constraints + "' WHERE Id ='" + this.Id+"'"))
                return true;
            return false;
        }
        public List<ListViewItem> getLessonsByDay(string day)
        {
            DataTable lessons = Program.get_dt("select L.startH, L.endH, C.Name,L.lessontype, "
                + "L.classname,c.semester from[lessons] L join courses C on l.CourseID = c.Id"
                + " where l.Day ='" + day + "' and l.tsid ='" + this.Id + "' order by starth");
            List<ListViewItem> list = new List<ListViewItem>();
            ListViewItem temp;
            for (int i = 0; i < lessons.Rows.Count; i++)
            {
                temp = new ListViewItem(lessons.Rows[i][0].ToString());
                temp.SubItems.Add(lessons.Rows[i][1].ToString());
                temp.SubItems.Add(lessons.Rows[i][2].ToString() + "-" + lessons.Rows[i][3].ToString());
                temp.SubItems.Add(lessons.Rows[i][4].ToString());
                temp.SubItems.Add(lessons.Rows[i][5].ToString());
           
                list.Add(temp);

            }
            return list;
        }
    }
}
