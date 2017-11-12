using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_project2
{
    public class HouseKeeper : User
    {
        public HouseKeeper(string ID, string name, string pass) : base(ID, name, pass) { }

        public int getClassStatistics(DataTable dt)
        {
            string start, end;
            int st, en,count=0;
            foreach(DataRow dr in dt.Rows)
            {
                
                start = dr[0].ToString().Substring(0,2);
                end = dr[1].ToString().Substring(0,2);
                st = Int32.Parse(start);
                en= Int32.Parse(end);
                count = count + (en - st);
            }

            return count;
        }
    }
}
